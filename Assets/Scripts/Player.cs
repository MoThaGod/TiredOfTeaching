using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent playerNav;

    Animator playerAN;

    //public bool to access from "usePC" to check wether or not players can move.
    public bool canMove;

    //Vector to move the player to.
    Vector3 moveTo;

    void Start()
    {
        //Get the the player NavMeshAgent
        playerNav = GetComponent<NavMeshAgent>();

        //Get the player animator component;
        playerAN = GetComponent<Animator>();

        //player can move as soon as the game starts
        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Use the navigaor to move the player to the "moveTo" position;
        playerNav.SetDestination(moveTo);

        //checking if the player can move
        if (canMove)
        {
            //Getting the keys to control the direction of the movement.
            //Changing the variable that controls what animation will be running on each key.
            if (Input.GetKey(KeyCode.W))
            {
                moveTo = transform.position + Vector3.forward;
                //If the player is holding shift the character will run.
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerAN.SetInteger("state", 5);
                }
                else
                {
                    playerAN.SetInteger("state", 1);
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveTo = transform.position + Vector3.back;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerAN.SetInteger("state", 5);
                }
                else
                {
                    playerAN.SetInteger("state", 1);
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveTo = transform.position + Vector3.left;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerAN.SetInteger("state", 5);
                }
                else
                {
                    playerAN.SetInteger("state", 1);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveTo = transform.position + Vector3.right;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerAN.SetInteger("state", 5);
                }
                else
                {
                    playerAN.SetInteger("state", 1);
                }
            }
        }

        //If non of the keys are being pressed, stop moving
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            moveTo = transform.position;
            playerAN.SetInteger("state", 0);
        }
    }
}
