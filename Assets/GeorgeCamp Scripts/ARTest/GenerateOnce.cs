using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOnce : MonoBehaviour
{
    [SerializeField]private static bool AlreadyGenerated = false;
    void Awake()
    {
        //generation unique du plan
        if (AlreadyGenerated) 
        {
            Destroy(gameObject);
        }
        AlreadyGenerated = true;
    }
}
