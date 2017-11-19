using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject[] infoPanel;
    public GameObject cancelButton;
    public GameObject shopButton;

    public Animator anim;

    private bool shopMenu = true;
    TowerPlacement build;

    private void Awake()
    {
        build = GameObject.Find("Shop").GetComponent<TowerPlacement>();
    }

    public void ShopMenu()
    {
        if (shopMenu)
        {
            anim.SetBool("isShopOpen", false);
            shopPanel.SetActive(true);
            shopMenu = false;
        }
        else
        {
            anim.SetBool("isShopOpen", true);
            shopPanel.SetActive(false);
            shopMenu = true;
            
        }
    }
    public void TowerPanel()
    {
        if (shopMenu)
        {
            shopPanel.SetActive(true);
            //shopButton.SetActive(true);
            cancelButton.SetActive(false);
            shopMenu = false;
        }
        else
        {
            shopPanel.SetActive(false);
            //shopButton.SetActive(false);
            cancelButton.SetActive(true);
            shopMenu = true;
        }
    }
    #region Info Panel
    public void Tower1InfoEnter()
    {
        infoPanel[0].SetActive(true);
    }
    public void Tower1InfoExit()
    {
        infoPanel[0].SetActive(false);
    }
    public void Tower2InfoEnter()
    {
        infoPanel[1].SetActive(true);
    }
    public void Tower2InfoExit()
    {
        infoPanel[1].SetActive(false);
    }
    public void Tower3InfoEnter()
    {
        infoPanel[2].SetActive(true);
    }
    public void Tower3InfoExit()
    {
        infoPanel[2].SetActive(false);
    }
    public void Tower4InfoEnter()
    {
        infoPanel[3].SetActive(true);
    }
    public void Tower4InfoExit()
    {
        infoPanel[3].SetActive(false);
    }
    public void Tower5InfoEnter()
    {
        infoPanel[4].SetActive(true);
    }
    public void Tower5InfoExit()
    {
        infoPanel[4].SetActive(false);
    }
    public void Tower6InfoEnter()
    {
        infoPanel[5].SetActive(true);
    }
    public void Tower6InfoExit()
    {
        infoPanel[5].SetActive(false);
    }
    public void Tower7InfoEnter()
    {
        infoPanel[6].SetActive(true);
    }
    public void Tower7InfoExit()
    {
        infoPanel[6].SetActive(false);
    }
    #endregion
    public void CancelBuild()
    {
        cancelButton.SetActive(false);
        //shopButton.SetActive(true);
        build.shadowTower = null;
    }
}
