using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ExplosionDamage(this.transform.position, 5f);
        Destroy(this.gameObject);
    }


    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("ApplyDamage",10);
            i++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}
//other.gameObject.SendMessage("ApplyDamage", 10);