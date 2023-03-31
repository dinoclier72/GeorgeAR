using System;
using UnityEngine;

[Serializable]
public class BuildingData
{
    [SerializeField]public Batiment batimentPrefab;
    [SerializeField]public Vector3 position;
    [SerializeField]public Vector3 scale;
    [SerializeField]public Color color;
}