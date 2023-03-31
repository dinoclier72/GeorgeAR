using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GeorgeAsset/Building")]
public class BuildingTypeSO : ScriptableObject
{
    //reference du batiment
    public Transform prefab;
    public Sprite sprite;
    public Batiment batimentPrefab;
}
