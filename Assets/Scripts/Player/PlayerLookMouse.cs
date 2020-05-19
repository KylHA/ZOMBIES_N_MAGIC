using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookMouse : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject BallPrefab;
    GameObject bullet, ball;
    RaycastHit hit;
    float speed = 8f;
    


    int layerMask = 1 << 8;
    int lookmask = 1 << 9;

    
    private void Start()
    {
        layerMask = ~layerMask;//invert layer mask
    }
    void Update()
    {
        RayLookat();

        if (Input.GetMouseButtonDown(0))
            Shoot();

        if (Input.GetKeyDown(KeyCode.V))
            CastSpell();
    }

    void RayLookat() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit,40f,lookmask))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.white);
        }
    }

    void Shoot() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 40f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);
            hit.collider.transform.parent.SendMessage("ApplyDamage", 5);
        }

        if (Input.GetMouseButtonDown(0))
        {
            bullet = Instantiate(bulletPrefab, GameObject.Find("Barrel").GetComponent<Transform>().position, GameObject.Find("Barrel").GetComponent<Transform>().rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 5100);
        }
    }

    void CastSpell() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            ball = Instantiate(BallPrefab, GameObject.Find("Barrel").GetComponent<Transform>().position, GameObject.Find("Barrel").GetComponent<Transform>().rotation) as GameObject;
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * 1100);
        }
    }
}