using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int curMoney;
    public int startMoney = 300;
    public static int curLives;
    public int startLives = 20;

    void Start()
    { 
        curMoney = startMoney;
        curLives = startLives;   
    }

  
}
