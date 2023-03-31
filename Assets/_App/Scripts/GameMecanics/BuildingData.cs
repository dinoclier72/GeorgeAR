using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "GeorgeAsset/BuildingData", order = 1),Serializable]
public class BuildingData : ScriptableObject
{
    public Batiment batimentPrefab;
    public Vector3 position;
    public Vector3 scale;
    public Color color;

    public BuildingData(Batiment batimentPrefab, Vector3 position, Vector3 scale, Color color)
    {
        this.batimentPrefab = batimentPrefab;
        this.position = position;
        this.scale = scale;
        this.color = color;
    }
}