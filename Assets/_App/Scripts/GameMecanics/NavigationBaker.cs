using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{
    //https://learn.unity.com/tutorial/runtime-navmesh-generation#5c7f8528edbc2a002053b492
    public NavMeshSurface[] surfaces;

    // Use this for initialization
    void Awake()
    {

        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }

}