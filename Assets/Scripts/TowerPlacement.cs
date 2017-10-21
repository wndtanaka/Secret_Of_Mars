using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour
{
    public LayerMask towerMask;
    public int buildTime = 3;

    private Transform currentTower;
    private Transform shadowTower;
    private bool hasPlaced = true;
    private PlaceableTower placeableTower;
    private PlaceableTower oldPlaceableTower;
    private Camera cam;
    private RaycastHit hit;
    private Ray ray;

    public TowerManagement towerOne;
    public TowerManagement towerTwo;
    public TowerManagement towerThree;
    public TowerManagement towerFour;
    public TowerManagement towerFive;
    public TowerManagement towerSix;
    public TowerManagement towerSeven;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {

        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (shadowTower != null && !hasPlaced)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~towerMask, QueryTriggerInteraction.Collide))
            {
                shadowTower.position = hit.transform.position + Vector3.up * 0.5f;
            }

            if (Input.GetMouseButtonDown(0))
            {

                if (IsLegalPosition())
                {
                    hasPlaced = true;
                    Debug.Log("Building");
                    StartCoroutine(PlacingTower());
                }
                else
                {
                    Debug.Log("A building already exist");
                }
                if (hit.collider.tag != "Platform")
                {
                    hasPlaced = false;
                    Debug.Log("Can not build on the ground, choose a platform instead");
                    //IsLegalPosition() == false;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, towerMask))
                {
                    if (oldPlaceableTower != null)
                    {
                        oldPlaceableTower.SetSelected(false);
                    }
                    hit.collider.gameObject.GetComponent<PlaceableTower>().SetSelected(true);
                    oldPlaceableTower = hit.collider.gameObject.GetComponent<PlaceableTower>();
                }
                else
                {
                    if (oldPlaceableTower != null)
                    {
                        oldPlaceableTower.SetSelected(false);
                    }
                }
            }
        }
    }
    bool IsLegalPosition()
    {
        if (placeableTower.colliders.Count > 0 || hit.collider.tag != "Platform")
        {
            return false;
        }
        return true;
    }
    public void BuyTower()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "Tower1")
        {
            if (PlayerStats.curMoney < towerOne.cost)
            {
                Debug.Log("Not enough money");
                return;
            }
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(towerOne.shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower2")
        {
            if (PlayerStats.curMoney < towerTwo.cost)
            {
                Debug.Log("Not enough money");
                return;
            }
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(towerTwo.shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower3")
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(towerThree.shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower4")
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(towerFour.shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower5")
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(towerFive.shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower6")
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(towerSix.shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower7")
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(towerSeven.shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
    }
    IEnumerator PlacingTower()
    {

        if (shadowTower.name == "Tower1S(Clone)")
        {
            PlayerStats.curMoney -= towerOne.cost;
            yield return new WaitForSeconds(buildTime);
            hasPlaced = false;
            currentTower = ((GameObject)Instantiate(towerOne.prefab, shadowTower.position, shadowTower.rotation)).transform;
            placeableTower = currentTower.GetComponent<PlaceableTower>();
            Destroy(shadowTower.gameObject);
            Debug.Log(currentTower.name + " Built! Money Left: " + PlayerStats.curMoney);
        }
        if (shadowTower.name == "Tower2S(Clone)")
        {
            PlayerStats.curMoney -= towerTwo.cost;
            yield return new WaitForSeconds(buildTime);
            hasPlaced = false;
            currentTower = ((GameObject)Instantiate(towerTwo.prefab, shadowTower.position, shadowTower.rotation)).transform;
            placeableTower = currentTower.GetComponent<PlaceableTower>();
            Destroy(shadowTower.gameObject);
            Debug.Log(currentTower.name + " Built! Money Left: " + PlayerStats.curMoney);
        }
    }
}
