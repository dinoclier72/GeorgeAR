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
    [SerializeField]private Image map;
    [SerializeField]private Canvas canvas;
    private Image georgeImage;
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
        if(isImageInMap(mousePosition,map,buildingImage,canvas) && isBuildingAllowed(activeBuildingType,mousePosition)){
            Image newBulding;
            if(activeBuildingType.batimentPrefab.tag == "George" && georgeImage != null){
                Destroy(georgeImage.gameObject);
            }
            newBulding = Instantiate(buildingImage, mousePosition, Quaternion.identity,parentObject);
            newBulding.sprite = activeBuildingType.sprite;
            newBulding.gameObject.tag = activeBuildingType.batimentPrefab.gameObject.tag;
            newBulding.gameObject.AddComponent<spriteInfo>().batimentPrefab = activeBuildingType.batimentPrefab;
            if(activeBuildingType.batimentPrefab.tag == "George"){
                georgeImage = newBulding;
            }
        }
    }

    protected bool isBuildingAllowed(BuildingTypeSO buildingTypeSO, Vector2 mousePosition){
        //verifie si le batiment peut etre placé
        BoxCollider2D boxCollider2D = buildingImage.GetComponent<BoxCollider2D>();

        if(Physics2D.OverlapBox(mousePosition, boxCollider2D.size, 0) != null){
            return false;
        }
        return true;
    }

    protected bool isImageInMap(Vector2 mousePosition,Image map,Image buildingImage,Canvas canvas){
        //verifie si l'image est dans la map
        Rect mapRect = map.GetComponent<RectTransform>().rect;
        float mapWidth = mapRect.width * canvas.scaleFactor;
        float mapHeight = mapRect.height * canvas.scaleFactor;

        Rect buildingRect = buildingImage.GetComponent<RectTransform>().rect;
        float buildingWidth = buildingRect.width * canvas.scaleFactor;
        float buildingHeight = buildingRect.height * canvas.scaleFactor;

        Rect canvasRect = canvas.GetComponent<RectTransform>().rect;
        float canvasWidth = canvasRect.width * canvas.scaleFactor;
        float canvasHeight = canvasRect.height * canvas.scaleFactor;

        Debug.Log("mousePosition.x - buildingWidth/2 " + (mousePosition.x - buildingWidth/2) + " > canvasWidth/2 - mapWidth/2 " + (canvasWidth/2 - mapWidth/2));

        if(mousePosition.x - buildingWidth/2 > canvasWidth/2 - mapWidth/2 && mousePosition.x + buildingWidth/2 < canvasWidth/2 + mapWidth/2 && mousePosition.y - buildingHeight/2 > canvasHeight/2 - mapHeight/2 && mousePosition.y + buildingHeight/2 < canvasHeight/2 + mapHeight/2){
            return true;
        }
        Debug.Log("Image not in map");
        return  false;
    }
}
