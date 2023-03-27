using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    [SerializeField]protected BuildingTypeSO activeBuildingType;
    private void Update()
    {
        //place le batiment sur le terrain
       if(Input.GetMouseButtonDown(0) && activeBuildingType != null && !EventSystem.current.IsPointerOverGameObject() && isBuildingAffordable(activeBuildingType))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            if (Physics.Raycast(ray, out hitPoint))
            { 
                Vector3 mouseWorldPosition = hitPoint.point;
                foreach(BuildingPrice buildingPrice in activeBuildingType.price)
                {
                    buildingPrice.resource.AddRessource(-buildingPrice.price);
                }
                Instantiate(activeBuildingType.prefab, mouseWorldPosition, Quaternion.identity);
            }      
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
    protected bool isBuildingAffordable(BuildingTypeSO buildingtypeSO)
    {
        //si le prix est null, on peut construire
        if (buildingtypeSO.price == null)
            return true;
        //sinon on vérifie si on a assez de ressources
        foreach(BuildingPrice buildingPrice in buildingtypeSO.price)
        {
            if(buildingPrice.resource.resourceAmount < buildingPrice.price)
            {
                return false;
            }
        }
        return true;
    }
}
