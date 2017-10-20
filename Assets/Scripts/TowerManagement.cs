using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManagement : MonoBehaviour
{
    public GameObject[] towers;
    private TowerPlacement towerPlacement;

    void Start()
    {
        towerPlacement = GetComponent<TowerPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void BuildTower(int i)
    {
        i--; // binary's sake
        towerPlacement.BuyTower(towers[i]);
        Debug.Log(towers[i].name);
    }
    public void TowerOne()
    {
        int i = 1;
        BuildTower(i);
    }
    public void TowerTwo()
    {
        int i = 2;
        BuildTower(i);
    }
    public void TowerThree()
    {
        int i = 3;
        BuildTower(i);
    }
    public void TowerFour()
    {
        int i = 4;
        BuildTower(i);
    }
    public void TowerFive()
    {
        int i = 5;
        BuildTower(i);
    }
    public void TowerSix()
    {
        int i = 6;
        BuildTower(i);
    }
    public void TowerSeven()
    {
        int i = 7;
        BuildTower(i);
    }
}
