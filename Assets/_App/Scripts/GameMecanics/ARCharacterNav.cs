using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class ARCharacterNav : CharacterNav
{
    private ARRaycastManager arRaycastManager;
    void Awake()
    {
        arRaycastManager = GameObject.Find("ARSessionOrigin").GetComponent<ARRaycastManager>();
    }
    void Update()
    {
        //deplacement du personnage
        if(Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            Touch touch = Input.GetTouch(0);
            List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(touch.position,hitPoints))
            {
                ARRaycastHit hitPoint = hitPoints[0];
                player.SetDestination( hitPoint.pose.position);
            }      
        }

        if(player.velocity != Vector3.zero)
        {
            playerAnimator.SetBool("walking",true);
        }
        else if(player.velocity == Vector3.zero)
        {
            playerAnimator.SetBool("walking", false);
        }
    }
}
