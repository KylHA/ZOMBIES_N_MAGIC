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

    // This would cast rays only against colliders in layer 8.
    // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
    private void Start()
    {
        layerMask = ~layerMask;
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, 0.5f, hit.point.z));
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
           bullet= Instantiate(bulletPrefab, GameObject.Find("Barrel").GetComponent<Transform>().position, GameObject.Find("Barrel").GetComponent<Transform>().rotation) as GameObject;

            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 5100);
        }

        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 40f, Color.white);
        }
    }
}