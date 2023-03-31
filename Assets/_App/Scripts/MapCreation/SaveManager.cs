using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private Transform map;
    // Start is called before the first frame update
    void Awake(){
        map = GameObject.Find("Map").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            Save();
        }
    }

    void Save(){
        List<BuildingData> buildings = new List<BuildingData>();
        Transform george = map.Find("George");
        foreach(Transform child in map){
            BuildingData building = new BuildingData(child.GetComponent<spriteInfo>().batimentPrefab, child.position,child.localScale, Color.white);
            buildings.Add(building);
        }
        Debug.Log(buildings.Count);
        SaveData saveData = new SaveData(buildings, Vector3.zero);
        Debug.Log(JsonUtility.ToJson(saveData));
    }
}

[Serializable]
class SaveData{
    public List<BuildingData> buildings;
    public Vector3 georgePosition;

    public SaveData(List<BuildingData> buildings, Vector3 georgePosition){
        this.buildings = buildings;
        this.georgePosition = georgePosition;
    }

    public String ToJson(){
        return JsonUtility.ToJson(this);
    }
}