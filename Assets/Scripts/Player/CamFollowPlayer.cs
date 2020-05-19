using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform player;
    
    private void Update()//Change in the future
    {   if(player.gameObject.scene.IsValid())
            this.transform.position = new Vector3(player.position.x, 20f, player.position.z);
    }
}