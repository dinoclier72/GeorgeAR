using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    [SerializeField]protected BuildingTypeSO activeBuildingType;
    [SerializeField]private Transform parentObject;
    [SerializeField]private Image buildingImage;
    private void Update()
    {
        //place le batiment sur le terrain
       if(Input.GetMouseButtonDown(0) && activeBuildingType != null && !EventSystem.current.IsPointerOverGameObject())
        {
            placeBuilding();
        }
    }
    public void SetActiveBuildingType(BuildingTypeSO buildingTypeSO)
    {
        //selectionne le type de batiment
        activeBuildingType = buildingTypeSO;
    }
    public BuildingTypeSO GetActiveBuildingType()
    {
        //retourne le type de batiment
        return activeBuildingType;
    }

    protected void placeBuilding(){
        Vector2 mousePosition = Input.mousePosition;
        Image newBulding = Instantiate(buildingImage, mousePosition, Quaternion.identity,parentObject);
        newBulding.sprite = activeBuildingType.sprite;
        newBulding.gameObject.AddComponent<spriteInfo>().batimentPrefab = activeBuildingType.batimentPrefab;
    }
}
