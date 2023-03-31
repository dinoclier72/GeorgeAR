using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ARBuildingPlacement : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private BuildingData buildingData;
    [SerializeField] private GameObject planGameObject;

    private GameObject buildingInstance;

    void Awake()
    {
        raycastManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
    }
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                buildingInstance = Instantiate(buildingData.batimentPrefab.gameObject, hits[0].pose.position, hits[0].pose.rotation);
                buildingInstance.transform.localScale = buildingData.scale;
                buildingInstance.GetComponent<MeshRenderer>().material.color = buildingData.color;
            }
        }
    }
}
