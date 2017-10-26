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

    public TowerManagement[] Towers;

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
                    // TODO Pop up text
                    StartCoroutine(PlacingTower());
                }
                else
                {
                    Debug.Log("A building already exist");
                    // TODO Pop up text
                }
                if (hit.collider.tag != "Platform")
                {
                    hasPlaced = false;
                    Debug.Log("Can not build on the ground, choose a platform instead");
                    // TODO Pop up text
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
            if (PlayerStats.curMoney < Towers[0].cost)
            {
                Debug.Log("Not enough money");
                // TODO Pop up text
                return;
            }
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(Towers[0].shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower2")
        {
            if (PlayerStats.curMoney < Towers[1].cost)
            {
                Debug.Log("Not enough money");
                // TODO Pop up text
                return;
            }
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(Towers[1].shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower3")
        {
            if (PlayerStats.curMoney < Towers[2].cost)
            {
                Debug.Log("Not enough money");
                // TODO Pop up text
                return;
            }
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(Towers[2].shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower4")
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(Towers[3].shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower5")
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(Towers[4].shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower6")
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(Towers[5].shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Tower7")
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            hasPlaced = false;
            shadowTower = ((GameObject)Instantiate(Towers[6].shadowPrefab)).transform;
            placeableTower = shadowTower.GetComponent<PlaceableTower>();
        }
    }
    IEnumerator PlacingTower()
    {

        if (shadowTower.name == "Tower1S(Clone)")
        {
            PlayerStats.curMoney -= Towers[0].cost;
            yield return new WaitForSeconds(buildTime);
            hasPlaced = false;
            currentTower = ((GameObject)Instantiate(Towers[0].prefab, shadowTower.position, shadowTower.rotation)).transform;
            placeableTower = currentTower.GetComponent<PlaceableTower>();
            Destroy(shadowTower.gameObject);
            Debug.Log(currentTower.name + " Built! Money Left: " + PlayerStats.curMoney);
        }
        if (shadowTower.name == "Tower2S(Clone)")
        {
            PlayerStats.curMoney -= Towers[1].cost;
            yield return new WaitForSeconds(buildTime);
            hasPlaced = false;
            currentTower = ((GameObject)Instantiate(Towers[1].prefab, shadowTower.position, shadowTower.rotation)).transform;
            placeableTower = currentTower.GetComponent<PlaceableTower>();
            Destroy(shadowTower.gameObject);
            Debug.Log(currentTower.name + " Built! Money Left: " + PlayerStats.curMoney);
        }
        if (shadowTower.name == "Tower3S(Clone)")
        {
            PlayerStats.curMoney -= Towers[2].cost;
            yield return new WaitForSeconds(buildTime);
            hasPlaced = false;
            currentTower = ((GameObject)Instantiate(Towers[2].prefab, shadowTower.position, shadowTower.rotation)).transform;
            placeableTower = currentTower.GetComponent<PlaceableTower>();
            Destroy(shadowTower.gameObject);
            Debug.Log(currentTower.name + " Built! Money Left: " + PlayerStats.curMoney);
        }
    }
}
