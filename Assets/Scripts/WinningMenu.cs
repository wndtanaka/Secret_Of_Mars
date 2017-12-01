using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningMenu : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Bonus()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
