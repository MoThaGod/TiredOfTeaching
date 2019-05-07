using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usePC : MonoBehaviour
{
    //bool to check whether or not the computer have been hacked.
    public bool hacked;

    //Black UI overlay to cover the 3D aspect of the game and focus on minigames
    public GameObject minigameOverlay;

    void Start()
    {
        //initial hacked state equals false
        hacked = false;
    }

    //Detects when the player enters the pc trigger
    void OnTriggerEnter(Collider other)
    {
        //Print can use the pc when the player enters in the collider
        Debug.Log("can use the pc");
    }

    //Detects when the player exits the pc trigger
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Can't use the pc no more");
    }
    
    //Detects the player every frame it is still inside the trigger
    void OnTriggerStay(Collider other)
    {
        //Detects if the players press E while inside the collider
        if (Input.GetKeyDown(KeyCode.E) && !hacked)
        {
            Debug.Log("E pressed");
            //set the overlay to true
            minigameOverlay.SetActive(true);
        }
    }
}
