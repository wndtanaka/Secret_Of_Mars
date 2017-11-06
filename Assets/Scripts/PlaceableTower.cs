using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTower : MonoBehaviour
{
    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();

    //public GameObject towerUI;
    private bool isSelected;

    private void Start()
    {
        //towerUI = GameObject.FindGameObjectWithTag("TowerUI");
    }

    private void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if (isSelected)
        {
            if (GUI.Button(new Rect(5 * scrW, 5 * scrH, scrW * 1.25f, scrH * 0.5f), "Upgrade"))
            {
                Debug.Log("Upgrade");
                isSelected = false;
            }
            if (GUI.Button(new Rect(6.25f * scrW, 5 * scrH, scrW * 1.25f, scrH * 0.5f), "Sell"))
            {
                Debug.Log("Sell");
                isSelected = false;
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
    //public void TowerUI(Vector3 pos)
    //{
    //    if (isSelected)
    //    {

    //        towerUI.SetActive(true);
    //        towerUI.transform.position = pos + (Vector3.up * 5f) + (Vector3.forward * 1f);
    //    }
    //    else
    //    {
    //        towerUI.SetActive(false);
    //    }
    //}
    //public void HideUI()
    //{
    //    towerUI.SetActive(false);
    //}
    //private void LateUpdate()
    //{
    //    towerUI.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
    //}
}
