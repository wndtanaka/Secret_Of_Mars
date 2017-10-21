using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int curMoney = 300;
    public int startMoney;
    public static int curHealth = 20;
    public int starthealth;

    void Start()
    { 
        curMoney = startMoney;
        curHealth = starthealth;   
    }

  
}
