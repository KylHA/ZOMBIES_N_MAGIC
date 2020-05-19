using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    float timer=0;
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2) 
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Destroy(this.gameObject);
    }
}