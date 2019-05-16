using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //this function is public so the button can access it when clicked.
    public void TryAgain()
    {
        //when the button is clicked the scene will be re-loaded
        SceneManager.LoadScene(0);
    }
}
