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

    public GameObject winScreen;

    bool startMinigame;

    float timer;

    public Text hackedCounter;

    //text object where the timer is going to be displayed
    public Text displayTimer;

    //target object to click on the minigame
    public GameObject target;

    int targetTotal;

    Player player;

    //accessable from targetDestroyer
    public int destroyed;

    //static variable so it is the same along all the usePC scripts in the scene
    public static int hackedCount;

    void Start()
    {
        //initial hacked state equals false
        hacked = false;

        //initial state of the minigame
        startMinigame = false;

        //set initial timer for the minigame to 10 seconds
        timer = 10;

        //the total of target has a fixed value of...
        targetTotal = 8;

        //Get the script player to access the bool "canMove"
        player = FindObjectOfType<Player>();

        destroyed = 0;

        hackedCount = 0;
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
            //start spawning the targets
            PlayMinigame();

            Debug.Log("E pressed");
            //set the overlay to true
            minigameOverlay.SetActive(true);

            //start playing the minigame
            startMinigame = true;

            //while the minigame is happening players can not move
            player.canMove = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            minigameOverlay.SetActive(false);
        }
    }

    //fixedUpdate to keep the time running in real time
    void FixedUpdate()
    {
        if (startMinigame && !player.canMove)
        {
            //once the minigame starts, start taking out one digit each second
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }
        else
        {
            timer = 10;
        }

        if (timer <= 0)
        {
            lose.SetActive(true);
        }

    }

    void Update ()
    {
        displayTimer.text = timer.ToString();

        //count destroyed targets
        if (destroyed == 7)
        {
            timer = 10;
            startMinigame = false;
            hacked = true;
            hackedCount++;
            minigameOverlay.SetActive(false);
            player.canMove = true;
            Destroy(this.gameObject);
        }

        if (hackedCount == 3)
        {
            winScreen.SetActive(true);
        }

        //Display how many computers have been hacked
        hackedCounter.text = "Hacked: " + hackedCount + "/5";
    }

    void PlayMinigame()
    {
        //create as many new targets as targetTotal is.
        for (int i = 0; i < targetTotal; i++)
        {
            GameObject newTarget;
            //Create a new target within the screen
            newTarget = Instantiate(target, new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0), Quaternion.identity);
            newTarget.SetActive(true);
            //Move the new target in the overlay within the canvas so it is visible.
            newTarget.transform.SetParent(minigameOverlay.transform);
        }
    }
}
