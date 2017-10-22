using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour {

    public Text livesText;

    void Update ()
    {
        livesText.text = PlayerStats.curLives.ToString() + " Lives";
    }
}
