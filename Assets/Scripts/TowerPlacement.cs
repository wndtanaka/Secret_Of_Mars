using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    public LayerMask towerMask;
    private int buildTime = 1;

    private Transform currentTower;
    private Transform level2Tower;
    [HideInInspector]
    public Transform level3Tower;
    [HideInInspector]
    public Transform shadowTower;
    private bool hasPlaced = true;
    private PlaceableTower placeableTower;
    private PlaceableTower oldPlaceableTower;
    private Camera cam;
    private RaycastHit hit;
    private Ray ray;
    private Renderer[] shadowRend;

    public TowerManagement[] towers;
    [HideInInspector]
    public static bool ui = false;

    public GUIManager gui;
    public Text popupMessage;


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
                    shadowRend = shadowTower.GetComponentsInChildren<Renderer>();
                    foreach (Renderer rend in shadowRend)
                    {
                        rend.enabled = true;
                    }
                }
                else
                {
                    shadowRend = shadowTower.GetComponentsInChildren<Renderer>();
                    foreach (Renderer rend in shadowRend)
                    {
                        rend.enabled = false;
                    }
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (IsLegalPosition())
                {
                    hasPlaced = true;
                    StartCoroutine(BuildingTower());
                    StartCoroutine(PlacingTower());
                }
                else if (!IsLegalPosition() && hit.collider.tag == "Platform")
                {
                    StartCoroutine(TowerExistMessage());
                }
                if (hit.collider.tag != "Platform")
                {
                    hasPlaced = false;
                    StartCoroutine(PlatformMessage());
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, towerMask)) // if we click on tower
                {
                    if (!ui)
                    {
                        //if (oldPlaceableTower != null)
                        //{
                        //    oldPlaceableTower.SetSelected(false);
                        //    //oldPlaceableTower.HideUI();
                        //}
                        hit.collider.gameObject.GetComponent<PlaceableTower>().SetSelected(true);
                        oldPlaceableTower = hit.collider.gameObject.GetComponent<PlaceableTower>();
                        //oldPlaceableTower.TowerUI(hit.transform.position);

                        ui = true;
                    }
                    else
                    {
                        if (oldPlaceableTower != null)
                        {
                            if (ui)
                            {
                                oldPlaceableTower.SetSelected(false);
                                //oldPlaceableTower.HideUI();
                                ui = false;
                            }
                            else
                            {
                                oldPlaceableTower.SetSelected(true);
                                ui = true;
                            }
                        }
                    }
                }
            }
        }
    }

    public bool IsLegalPosition()
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
                    gui.cancelButton.SetActive(false);
                    StartCoroutine(NotEnoughMoney());
                    return;
                }
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
                //hasPlaced = false;
                currentTower = ((GameObject)Instantiate(towers[i].prefab, shadowTower.position, shadowTower.rotation)).transform;
                placeableTower = currentTower.GetComponent<PlaceableTower>();
                Destroy(shadowTower.gameObject);
                StartCoroutine(BuildingTower());
                gui.cancelButton.SetActive(false);
            }
        }

    }
    public void UpgradeTower()
    {
        for (int i = 1; i < towers.Length; i++)
        {
            if (currentTower != null)
            {
                if (currentTower.name == "Tower" + i.ToString() + "(Clone)")
                {
                    if (PlayerStats.curMoney < towers[i].level2Cost)
                    {
                        StartCoroutine(NotEnoughMoney());
                        return;
                    }
                    else
                    {
                        PlayerStats.curMoney -= towers[i].level2Cost;
                        Debug.Log("Upgrading");
                        level2Tower = ((GameObject)Instantiate(towers[i].level2Prefab, currentTower.position, currentTower.rotation)).transform;
                        placeableTower = level2Tower.GetComponent<PlaceableTower>();
                        Destroy(currentTower.gameObject);
                        return;
                    }
                }
            }
            else if (level2Tower.name == "Tower" + i.ToString() + "Level2(Clone)")
            {
                if (PlayerStats.curMoney < towers[i].level3Cost)
                {
                    StartCoroutine(NotEnoughMoney());
                    return;
                }
                else
                {
                    PlayerStats.curMoney -= towers[i].level3Cost;
                    Debug.Log("Upgrading");
                    level3Tower = ((GameObject)Instantiate(towers[i].level3Prefab, level2Tower.position, level2Tower.rotation)).transform;
                    placeableTower = level3Tower.GetComponent<PlaceableTower>();
                    Destroy(level2Tower.gameObject);
                    return;
                }
            }
        }
    }
    public void SellTower()
    {
        for (int i = 1; i < towers.Length; i++)
        {
            if (currentTower != null)
            {
                if (currentTower.name == "Tower" + i.ToString() + "(Clone)")
                {
                    PlayerStats.curMoney += towers[i].sellPrice;                  
                    Destroy(currentTower.gameObject);
                    return;
                }
            }
        }
    }
    IEnumerator TowerExistMessage()
    {
        if (popupMessage.enabled)
            popupMessage.enabled = false;
        popupMessage.text = "A tower already exist.";
        popupMessage.enabled = true;
        yield return new WaitForSeconds(3);
        popupMessage.enabled = false;
    }
    IEnumerator PlatformMessage()
    {
        if (popupMessage.enabled)
            popupMessage.enabled = false;
        popupMessage.text = "Can not build on the ground, choose a platform instead.";
        popupMessage.enabled = true;
        yield return new WaitForSeconds(3);
        popupMessage.enabled = false;
    }
    IEnumerator NotEnoughMoney()
    {
        if (popupMessage.enabled)
            popupMessage.enabled = false;
        popupMessage.text = "Not Enough Money!";
        popupMessage.enabled = true;
        yield return new WaitForSeconds(3);
        popupMessage.enabled = false;
    }
    IEnumerator BuildingTower()
    {
        if (popupMessage.enabled)
            popupMessage.enabled = false;
        popupMessage.text = "Building Tower!";
        popupMessage.enabled = true;
        yield return new WaitForSeconds(3);
        popupMessage.enabled = false;
    }
}
