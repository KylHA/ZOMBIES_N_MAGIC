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
            StartCoroutine(Goplayer(other));
        }
    }

    IEnumerator Goplayer(Collider other)
    {
        yield return new WaitForSeconds(0.5f);
        pos = other.transform.position;
    }    
}
