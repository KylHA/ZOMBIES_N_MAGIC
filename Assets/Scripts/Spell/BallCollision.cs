using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class BallCollision : MonoBehaviour
{//ADD LAYER MASK

    public float Exp_Radius = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        ExplosionDamage(this.transform.position, Exp_Radius);
        Destroy(this.gameObject);
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        
        List<Collider> hits= hitColliders.ToList<Collider>();

        if (hits.Contains(hits.Find(x=>x.tag=="Player")))
        {
            GameObject.FindGameObjectWithTag("Player").SendMessage("ApplyDamage", 10);
        }

        hits.RemoveAll(x => x.tag!="Enemy" );

        foreach (var item in hits)
        {
            item.SendMessage("ApplyDamage", 10);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, Exp_Radius);
    }
}