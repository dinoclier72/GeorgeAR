using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GeorgeAsset/PlayerResource")]
public class Resource : ScriptableObject
{
    public event EventHandler OnResourceUpdated;
    //definiton de la ressource
    public string resourceName;
    public int resourceAmount;
    //manipulation des ressources
    public void AddRessource(int amount)
    {
        resourceAmount += amount;
        OnResourceUpdated(this, EventArgs.Empty);
    }

    public int GetAmount()
    {
        return resourceAmount;
    }
}
