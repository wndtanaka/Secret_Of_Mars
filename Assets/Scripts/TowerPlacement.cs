using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour
{
    public LayerMask towerMask;
    private int buildTime = 1;

    private Transform currentTower;
    [HideInInspector]
    public Transform shadowTower;
    private bool hasPlaced = true;
    private PlaceableTower placeableTower;
    private PlaceableTower oldPlaceableTower;
    private Camera cam;
    private RaycastHit hit;
    private Ray ray;

    public TowerManagement[] towers;

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
                shadowTower.position = hit.transform.position + Vector3.up * 0f;
                if (hit.collider.tag == "Platform")
                {
                    shadowTower.gameObject.SetActive(true);
                }
                else
                {
                    shadowTower.gameObject.SetActive(false);
                }
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
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Cancel Build");
                Destroy(shadowTower.gameObject);
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
                    oldPlaceableTower.TowerUI(hit.transform.position);
                }
                else
                {
                    if (oldPlaceableTower != null)
                    {
                        oldPlaceableTower.SetSelected(false);
                        oldPlaceableTower.TowerUI(Vector3.zero);
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
        for (int i = 0; i < towers.Length; i++)
        {
            if (EventSystem.current.currentSelectedGameObject.name == ("Tower" + i.ToString()))
            {
                if (PlayerStats.curMoney < towers[i].cost)
                {
                    Debug.Log("Not enough money");
                    // TODO Pop up text
                    return;
                }
                Debug.Log(EventSystem.current.currentSelectedGameObject.name);
                hasPlaced = false;
                shadowTower = ((GameObject)Instantiate(towers[i].shadowPrefab)).transform;
                placeableTower = shadowTower.GetComponent<PlaceableTower>();
            }
        }
    }
    IEnumerator PlacingTower()
    {
        for (int i = 0; i < towers.Length; i++)
        {
            if (shadowTower.name == "Tower" + i.ToString() + "S(Clone)")
            {
                PlayerStats.curMoney -= towers[i].cost;
                yield return new WaitForSeconds(buildTime);
                hasPlaced = false;
                currentTower = ((GameObject)Instantiate(towers[i].prefab, shadowTower.position, shadowTower.rotation)).transform;
                placeableTower = currentTower.GetComponent<PlaceableTower>();
                Destroy(shadowTower.gameObject);
                Debug.Log(currentTower.name + " Built! Money Left: " + PlayerStats.curMoney);
            }
        }

    }
}
