using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlayerPoz : MonoBehaviour
{
    public Vector3 pos;
    private void Awake()
    {
        pos = GetComponentInParent<Transform>().position;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player") 
        {
            pos = other.transform.position;
        }
    }
}
