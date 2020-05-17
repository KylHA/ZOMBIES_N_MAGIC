using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    List<GameObject> addDamage = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            other.gameObject.SendMessage("ApplyDamage", 10);
    }



}
