using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject[] towers;

    private TowerPlacement towerPlacement;
    private float scrW, scrH;
    private bool shopButton = true;
    private bool shopPanel = false;
    // Use this for initialization
    void Start()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;
        Screen.SetResolution(1980,1080,true);

        towerPlacement = GetComponent<TowerPlacement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //void OnGUI()
    //{
    //    if (shopButton)
    //    {
    //        if (GUI.Button(new Rect(scrW * 0f, scrH * 0, 75, 75), "Shop"))
    //        {
    //            shopButton = false;
    //            shopPanel = true;
    //        }
    //    }
    //    if (shopPanel)
    //    {
    //        if (GUI.Button(new Rect(scrW * 0f, scrH * 0, 75, 75), "Back"))
    //        {
    //            shopButton = true;
    //            shopPanel = false;
    //        }
    //        GUI.Box(new Rect(scrW * 1.15f, scrH * 0f, 525, 75), "");
    //        for (int i = 0; i < towers.Length; i++)
    //        {
    //            if (GUI.Button(new Rect(scrW *(i+1)*1.175f, scrH * 0f, 75, 75), towers[i].name))
    //            {
    //                towerPlacement.SetItem(towers[i]);
    //            }
    //        }

    //    }
    //}
}
