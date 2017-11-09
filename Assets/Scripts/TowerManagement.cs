using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TowerManagement
{
    public GameObject shadowPrefab;
    public GameObject prefab;
    public int cost;
    public int sellPrice;

    public GameObject level2Prefab;
    public int level2Cost;
    public int level2SellPrice;

    public GameObject level3Prefab;
    public int level3Cost;
    public int level3SellPrice;
}
