using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Resource resource;
    [SerializeField] private int amount = 1;
    public void pickup()
    {
        //ramasser l'item
        resource.AddRessource(amount);
        Destroy(gameObject);
    }
}
