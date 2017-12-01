using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTower : MonoBehaviour
{
    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();
    public GUISkin skin;
    public TowerPlacement towerPlacement;

    TowerManagement[] towers;
    private bool isSelected;
    Vector3 mousePos;

    void Start()
    {
        towerPlacement = GameObject.FindGameObjectWithTag("ShopPanel").GetComponent<TowerPlacement>();
    }
    private void OnGUI()
    {
        GUI.skin = skin;

        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        mousePos = new Vector3(Input.mousePosition.x, Screen.height - Input.mousePosition.y, Input.mousePosition.y);

        Rect upgradeButton = new Rect(6.75f * scrW, 8 * scrH, scrW * 1.25f, scrH * 0.5f);
        Rect sellButton = new Rect(8f * scrW, 8 * scrH, scrW * 1.25f, scrH * 0.5f);

        if (isSelected)
        {
            for (int i = 0; i < towerPlacement.towers.Length; i++)
            {
                GUI.Box(new Rect(6.75f * scrW, 7.5f * scrH, scrW * 2.5f, scrH * 0.5f), NameChanger(towerPlacement.towerOptions.name));
                if (upgradeButton.Contains(mousePos))
                {
                    if (towerPlacement.towerOptions.name == "Tower" + i.ToString() + "(Clone)")
                    {
                        if (GUI.Button(upgradeButton, towerPlacement.towers[i].level2Cost.ToString() + " Energy"))
                        {
                            isSelected = false;
                            TowerPlacement.ui = false;
                            towerPlacement.UpgradeTower(towerPlacement.towerOptions);
                        }
                    }
                    else
                    {
                        if (towerPlacement.towerOptions.name == "Tower" + i.ToString() + "Level2(Clone)")
                        {
                            GUI.Button(upgradeButton, "Max Level");
                        }
                    }
                }
                else
                {
                    if (towerPlacement.towerOptions.name == "Tower" + i.ToString() + "Level2(Clone)")
                    {
                        GUI.Button(upgradeButton, "Max Level");
                    }
                    else
                    {
                        GUI.Button(upgradeButton, "Upgrade");
                    }
                }
                if (sellButton.Contains(mousePos))
                {
                    if (towerPlacement.towerOptions.name == "Tower" + i.ToString() + "(Clone)")
                    {
                        if (GUI.Button(sellButton, towerPlacement.towers[i].sellPrice.ToString() + " Energy"))
                        {
                            isSelected = false;
                            TowerPlacement.ui = false;
                            towerPlacement.SellTower(towerPlacement.towerOptions);
                        }
                    }
                    else if (towerPlacement.towerOptions.name == "Tower" + i.ToString() + "Level2(Clone)")
                    {
                        if (GUI.Button(sellButton, towerPlacement.towers[i].level2SellPrice.ToString() + " Energy"))
                        {
                            isSelected = false;
                            TowerPlacement.ui = false;
                            towerPlacement.SellTower(towerPlacement.towerOptions);
                        }
                    }

                }
                else
                {
                    GUI.Button(sellButton, "Sell");
                }
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
