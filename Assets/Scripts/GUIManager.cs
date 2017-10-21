using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject infoPanel;

    private bool shopMenu = true;

    public void ShopMenu()
    {
        if (shopMenu)
        {
            shopPanel.SetActive(true);
            shopMenu = false;
        }
        else
        {
            shopPanel.SetActive(false);
            shopMenu = true;
        }
    }
    public void TowerPanel()
    {
        if (shopMenu)
        {
            shopPanel.SetActive(true);
            shopMenu = false;
        }
        else
        {
            shopPanel.SetActive(false);
            shopMenu = true;
        }
    }
    public void Tower1InfoEnter()
    {
        infoPanel.SetActive(true);
    }
    public void Tower1InfoExit()
    {
        infoPanel.SetActive(false);
    }

}
