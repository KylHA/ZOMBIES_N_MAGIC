using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{

    //Change to stay and add animation timer.
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(1, 0, 1), this.transform.position * -1);
            other.GetComponent<UnitStats>().Health -= 5;
        }
    }
}