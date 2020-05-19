using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform player;
    
    private void Update()
    {
        this.transform.position = new Vector3(player.position.x, 20f, player.position.z);
    }
}