using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    float timer=0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3) 
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Enemy")
            collision.gameObject.GetComponent<UnitStats>().Health -= 5;
        Destroy(this.gameObject);
    }
}