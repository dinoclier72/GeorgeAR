using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
public class PlacePlaygroundOnARPlane : MonoBehaviour
{
    private static bool Generated = false;
    [SerializeField] private GameObject playgroundPrefab;
    [SerializeField] private ARPlaneManager arPlaneManager;

    private void Awake()
    {
        //prend la référnece du plane manager
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlaneChanged;
        Generated = false;
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if(args.added != null && !Generated)
        {
            //fait apparaitre le plan
            ARPlane arPlane = args.added[0];
            Generated = true;
            Instantiate(playgroundPrefab, arPlane.transform.position, arPlane.transform.rotation);
            arPlaneManager.requestedDetectionMode  = PlaneDetectionMode.None;
            disableAllPlanes();
        }
    }

    private void disableAllPlanes()
    {
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }
}
