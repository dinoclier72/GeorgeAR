using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [SerializeField]private Transform parent;
    [SerializeField]private TMP_InputField inputField;
    [SerializeField]private Button saveButton;

    void Awake(){
        saveButton.onClick.AddListener(Save);
    }
    // // seulement pour tester le chargement
    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.F12)){
    //         SaveData save = JsonUtility.FromJson<SaveData>(Save());
    //     }
    // }

    void Save(){
        List<BuildingData> buildings = new List<BuildingData>();
        GeorgeData georgeData = new GeorgeData();;
        //TODO: save george
        foreach(Transform child in parent){
            if(child.tag == "batiment"){
                BuildingData building = new BuildingData();
                building.batimentPrefab = child.GetComponent<spriteInfo>().batimentPrefab.GetComponent<Batiment>();
                building.position = new Vector3(child.position.x,0,child.position.y);
                building.scale = child.localScale;
                building.color = Color.white;
                buildings.Add(building);
            }
            if(child.tag == "George"){
                georgeData.georgePrefab = child.GetComponent<spriteInfo>().batimentPrefab.GetComponent<George>();
                georgeData.position = new Vector3(child.position.x,0,child.position.y);
                georgeData.scale = child.localScale;
                georgeData.color = Color.white;
            }
        }
        SaveData saveData = new SaveData(buildings, georgeData);
        String json = saveData.ToJson();
        String SaveName = inputField.text;
        File.WriteAllText(Application.dataPath + "/_App/saves/"+SaveName+".json", json);
    }
}

[Serializable]
public class SaveData{
    public List<BuildingData> buildings;
    public GeorgeData georgeData;

    public SaveData(List<BuildingData> buildings, GeorgeData georgeData){
        this.buildings = buildings;
        this.georgeData = georgeData;
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