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
        collision.gameObject.SendMessage("ApplyDamage", 2);
        Destroy(this.gameObject);
    }
}