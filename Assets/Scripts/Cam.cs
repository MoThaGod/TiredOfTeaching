using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    //Use to get player position.
    public Transform player;

    void Start()
    {

    }
    void FixedUpdate()
    {
        //Move with the player on the X and Z axis.
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
    }
}
