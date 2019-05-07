using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadNameTag : MonoBehaviour
{
    //set the prof name in the inspector
    public string profName;

    //text object to display name
    public Text displayName;

    public GameObject textBox;
    public GameObject player;

    void OnTriggerEnter (Collider other)
    {
        //Detect when player has entered the trigger
        if (other.gameObject == player)
        {
            Debug.Log("Can Read name");
            displayName.text = profName;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Detect when player has exit the trigger
        if (other.gameObject == player)
        {
            displayName.text = "";
        }
    }
}
