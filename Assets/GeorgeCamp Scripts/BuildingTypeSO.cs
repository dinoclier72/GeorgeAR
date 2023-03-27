using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingPrice
{
    //prix de construction
    public Resource resource;
    public int price;
}

[CreateAssetMenu(menuName = "GeorgeAsset/Building")]
public class BuildingTypeSO : ScriptableObject
{
    //reference du batiment
    public Transform prefab;
    public Sprite sprite;
    public BuildingPrice[] price;
}
