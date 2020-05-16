using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookMouse : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bullet;
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
    }
}