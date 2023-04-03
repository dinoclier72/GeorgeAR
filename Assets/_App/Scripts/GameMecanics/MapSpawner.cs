using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    private SaveData saveData;

    [SerializeField]private Transform plane;

    void Awake(){
        MeshRenderer meshRenderer = plane.GetComponent<MeshRenderer>();
        GameHandler.LoadBaseSaveData(Application.dataPath+"/_App/saves/empty.json");
        saveData = GameHandler.GetSaveData();
        foreach(BuildingData building in saveData.buildings){
            Batiment buildingObject = Instantiate(building.batimentPrefab);
            buildingObject.transform.position = building.position*meshRenderer.bounds.size.x/350;
        }
        George george = Instantiate(saveData.georgeData.georgePrefab);
        george.transform.position = saveData.georgeData.position*meshRenderer.bounds.size.x/350;
    }
}
