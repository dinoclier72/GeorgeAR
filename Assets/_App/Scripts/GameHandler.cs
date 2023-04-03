using UnityEngine;
using System.IO;    
public static class GameHandler{
    private static SaveData DefaultSave;
    private static SaveData CurrentSave;

    public static void LoadBaseSaveData(string filePath){     
        string json = File.ReadAllText(filePath);
        DefaultSave = JsonUtility.FromJson<SaveData>(json);
    }
    public static void SelectSaveData(string filePath){
        CurrentSave = JsonUtility.FromJson<SaveData>(File.ReadAllText(filePath));
    }
    public static SaveData GetSaveData(){
        if(CurrentSave == null)
            return DefaultSave;
        return CurrentSave;
    }
}