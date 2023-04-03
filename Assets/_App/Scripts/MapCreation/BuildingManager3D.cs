using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager3D : BuildingManager
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && activeBuildingType != null && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mousePosition = Input.mousePosition;
            placeBuilding(mousePosition);
        }
    }
}
