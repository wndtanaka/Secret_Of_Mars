using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTower : MonoBehaviour
{
    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();

    public TowerPlacement towerPlacement;

    private bool isSelected;

    void Start()
    {
        towerPlacement = GameObject.FindGameObjectWithTag("ShopPanel").GetComponent<TowerPlacement>();
    }
    private void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if (isSelected)
        {
            if (GUI.Button(new Rect(8 * scrW, 8 * scrH, scrW * 1.25f, scrH * 0.5f), "Upgrade"))
            {
                isSelected = false;
                TowerPlacement.ui = false;
                towerPlacement.UpgradeTower();
            }
            if (GUI.Button(new Rect(9.25f * scrW, 8 * scrH, scrW * 1.25f, scrH * 0.5f), "Sell"))
            {
                Debug.Log("Sell");
                isSelected = false;
                TowerPlacement.ui = false;
                towerPlacement.SellTower();
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
}
