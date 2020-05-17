using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookMouse : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject BallPrefab;
    GameObject bullet,ball;
    RaycastHit hit;
    float speed = 8f;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x,0.5f,hit.point.z));
        }

        if(Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0)) 
        {
            bullet=Instantiate(bulletPrefab, GameObject.Find("Barrel").GetComponent<Transform>().position, GameObject.Find("Barrel").GetComponent<Transform>().rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 3100 );
        }
        if (Physics.Raycast(ray, out hit) && Input.GetKeyDown(KeyCode.V))
        {
            ball = Instantiate(BallPrefab, GameObject.Find("Barrel").GetComponent<Transform>().position, GameObject.Find("Barrel").GetComponent<Transform>().rotation) as GameObject;
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * 1100);
        }
    }
}