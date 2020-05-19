using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Testgo : MonoBehaviour
{
    GoPlayerPoz gpz;
    void Awake()
    {
        gpz = this.GetComponentInChildren<GoPlayerPoz>();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<NavMeshAgent>().destination = gpz.pos;
    }
}
