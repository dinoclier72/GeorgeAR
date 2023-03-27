using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class ARBuildingManager : BuildingManager    
{
    //voir building manager
    [SerializeField]private ARRaycastManager arRaycastManager;
    private void Awake()
    {
        arRaycastManager = GameObject.Find("ARSessionOrigin").GetComponent<ARRaycastManager>();
    }
private void Update()
    {
        
       if(Input.touchCount > 0 && activeBuildingType != null && !EventSystem.current.IsPointerOverGameObject() && isBuildingAffordable(activeBuildingType))
        {
            Touch touch = Input.GetTouch(0);
            List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(touch.position,hitPoints))
            {
                ARRaycastHit hitPoint = hitPoints[0];
                Vector3 mouseWorldPosition = hitPoint.pose.position;
                foreach(BuildingPrice buildingPrice in activeBuildingType.price)
                {
                    buildingPrice.resource.AddRessource(-buildingPrice.price);
                }
                Instantiate(activeBuildingType.prefab, mouseWorldPosition, Quaternion.identity);
            }      
        }
    }
}
