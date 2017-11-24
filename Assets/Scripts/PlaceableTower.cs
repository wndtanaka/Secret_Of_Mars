using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTower : MonoBehaviour
{
    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();
    public GUISkin skin;
    public TowerPlacement towerPlacement;

    private bool isSelected;

    void Start()
    {
        towerPlacement = GameObject.FindGameObjectWithTag("ShopPanel").GetComponent<TowerPlacement>();
    }
    private void OnGUI()
    {
        GUI.skin = skin;

        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if (isSelected)
        {
            GUI.Box(new Rect(6.75f * scrW, 7.5f * scrH, scrW * 2.5f, scrH * 0.5f), NameChanger(towerPlacement.towerOptions.name));
            if (GUI.Button(new Rect(6.75f * scrW, 8 * scrH, scrW * 1.25f, scrH * 0.5f), "Upgrade"))
            {
                isSelected = false;
                TowerPlacement.ui = false;
                towerPlacement.UpgradeTower(towerPlacement.towerOptions);
            }
            if (GUI.Button(new Rect(8f * scrW, 8 * scrH, scrW * 1.25f, scrH * 0.5f), "Sell"))
            {
                isSelected = false;
                TowerPlacement.ui = false;
                towerPlacement.SellTower(towerPlacement.towerOptions);
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Tower")
        {
            colliders.Add(col);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Tower")
        {
            colliders.Remove(col);
        }
    }
    public void SetSelected(bool select)
    {
        isSelected = select;
    }
    string NameChanger(string towerName)
    {
        switch (towerName)
        {
            case "Tower1(Clone)":
                towerName = "Sobek";
                break;
            case "Tower1Level2(Clone)":
                towerName = "Sobek Lv.2";
                break;
            case "Tower3(Clone)":
                towerName = "Sekhmet";
                break;
            case "Tower3Level2(Clone)":
                towerName = "Sekhmet Lv.2";
                break;
            case "Tower4(Clone)":
                towerName = "Ra";
                break;
            case "Tower4Level2(Clone)":
                towerName = "Ra Lv.3";
                break;
            case "Tower6(Clone)":
                towerName = "Anubis";
                break;
            case "Tower6Level2(Clone)":
                towerName = "Anubis Lv.2";
                break;
        }
        return towerName;
    }
}
