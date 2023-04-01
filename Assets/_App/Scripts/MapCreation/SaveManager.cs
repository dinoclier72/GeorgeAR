using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField]private Transform parent;
    [SerializeField]private TMP_InputField inputField;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F12)){
            SaveData save = JsonUtility.FromJson<SaveData>(Save());
        }
    }

    String Save(){
        List<BuildingData> buildings = new List<BuildingData>();
        Transform george = parent.Find("George");
        //TODO: save george
        foreach(Transform child in parent){
            BuildingData building = new BuildingData();
            building.batimentPrefab = child.GetComponent<spriteInfo>().batimentPrefab;
            building.position = new Vector3(child.position.x,0,child.position.y);
            building.scale = child.localScale;
            building.color = Color.white;
            buildings.Add(building);
        }
        SaveData saveData = new SaveData(buildings, Vector3.zero);
        String json = saveData.ToJson();
        String SaveName = inputField.text;
        File.WriteAllText(Application.dataPath + "/_App/saves/"+SaveName+".json", json);
        return json;
    }
}

[Serializable]
public class SaveData{
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

[Serializable]
public class BuildingData
{
    [SerializeField]public Batiment batimentPrefab;
    [SerializeField]public Vector3 position;
    [SerializeField]public Vector3 scale;
    [SerializeField]public Color color;
}

[Serializable]
public class GeorgeData
{
    [SerializeField]public George georgePrefab;
    [SerializeField]public Vector3 position;
    [SerializeField]public Vector3 scale;
    [SerializeField]public Color color;
}