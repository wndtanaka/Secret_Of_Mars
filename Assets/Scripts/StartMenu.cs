using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{


    public void EnterGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowOptions()
    {
        Debug.Log("Show Options Menu");
    }

    public void Quit ()
    {
        Application.Quit();
	}
	
	
}
