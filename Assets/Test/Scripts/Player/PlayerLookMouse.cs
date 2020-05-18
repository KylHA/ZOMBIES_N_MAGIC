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
    GameObject lookObj;


    int layerMask = 1 << 8;

    
    private void Start()
    {
        layerMask = ~layerMask;//invert layer mask
        lookObj = new GameObject();
    }
    void Update()
    {
        RayLookat();

        LooktoObj();
    }

    void RayLookat() 
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

        
        if (Physics.Raycast(ray, out hit) && Input.GetKeyDown(KeyCode.V))
        {
            ball = Instantiate(BallPrefab, GameObject.Find("Barrel").GetComponent<Transform>().position, GameObject.Find("Barrel").GetComponent<Transform>().rotation) as GameObject;
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * 1100);
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 40f, layerMask) && Input.GetMouseButtonDown(0))
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

    void LooktoObj() 
    {
        lookObj.transform.position =new Vector3(Input.mousePosition.x,.5f,Input.mousePosition.z);

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Vector3.Distance(transform.position,lookObj.transform.position), Color.white);

    }
}