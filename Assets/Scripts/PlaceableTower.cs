using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTower : MonoBehaviour
{
    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();

    public GameObject towerUI;
    private bool isSelected;
    private bool selectMenu;

    private void Start()
    {
        towerUI = GameObject.FindGameObjectWithTag("TowerUI");
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
        selectMenu = select;
    }
    public void TowerUI(Vector3 pos)
    {
        if (isSelected)
        {
            
            towerUI.SetActive(true);
            towerUI.transform.position = pos + (Vector3.up * 5f) + (Vector3.forward * 1f);
        }
        else
        {
            towerUI.SetActive(false);
        }
    }
    public void HideUI()
    {
        towerUI.SetActive(false);
    }
    private void LateUpdate()
    {
        towerUI.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
    }
}
