using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class usePC : MonoBehaviour
{
    //bool to check whether or not the computer have been hacked.
    public bool hacked;

    //Black UI overlay to cover the 3D aspect of the game and focus on minigames
    public GameObject minigameOverlay;

    //game object that overlays the screen and creates a lose screen.
    public GameObject lose;

    bool startMinigame;

    float timer;

    //text object where the timer is going to be displayed
    public Text displayTimer;

    void Start()
    {
        //initial hacked state equals false
        hacked = false;

        //initial state of the minigame
        startMinigame = false;

        //set initial timer for the minigame to 10 seconds
        timer = 10;
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
        if (Input.GetKey(KeyCode.E) && !hacked)
        {
            Debug.Log("E pressed");
            //set the overlay to true
            minigameOverlay.SetActive(true);

            //start playing the minigame
            startMinigame = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            minigameOverlay.SetActive(false);
        }
    }

    //fixedUpdate to keep the time running in real time
    void FixedUpdate()
    {
        if (startMinigame)
        {
            //once the minigame starts, start taking out one digit each second
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }
        if (timer <= 0)
        {
            lose.SetActive(true);
        }
    }

    void Update ()
    {
        displayTimer.text = timer.ToString();
    }
}
