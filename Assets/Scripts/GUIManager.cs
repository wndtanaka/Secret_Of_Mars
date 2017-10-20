using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject tower1Button;

    private bool shopMenu = true;
    private bool buyTower1 = true;

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
    public void BuyTower1()
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
}
