using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//copied this code from the internet to click on an image
/* https://stackoverflow.com/questions/40567303/onclick-event-for-image-in-unity */
public class targetDestroyer : MonoBehaviour, IPointerClickHandler
{
    usePC usepc;

    void Start ()
    {
        usepc = FindObjectOfType<usePC>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        usepc.destroyed++;
        //Destory the game object after being clicked.
        Destroy(this.gameObject);
    }
}
