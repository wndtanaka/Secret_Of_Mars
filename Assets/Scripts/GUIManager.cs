using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject tower1InfoPanel;
    public GameObject tower2InfoPanel;

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
        tower1InfoPanel.SetActive(true);
    }
    public void Tower1InfoExit()
    {
        tower1InfoPanel.SetActive(false);
    }
    public void Tower2InfoEnter()
    {
        tower2InfoPanel.SetActive(true);
    }
    public void Tower2InfoExit()
    {
        tower2InfoPanel.SetActive(false);
    }
}
