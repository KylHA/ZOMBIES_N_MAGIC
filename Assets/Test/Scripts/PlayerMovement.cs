using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed=8f;

    Rigidbody rb;
    Vector3 move;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        move.x = Input.GetAxisRaw("Vertical") *-1;
        move.z = Input.GetAxisRaw("Horizontal");
        move.y = 0.5f;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        if (!Input.anyKeyDown) 
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("ItemDatabase").SendMessage("AddItemToCharbyName", collision.gameObject.name);
    }
}