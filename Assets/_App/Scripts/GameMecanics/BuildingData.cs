using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "GeorgeAsset/BuildingData", order = 1)]
public class BuildingData : ScriptableObject
{
    public Batiment batimentPrefab;
    public Vector3 scale;
    public Color color;
}