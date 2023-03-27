using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    //categorise les loots
    public Item item;
    public float Chance = 100;
    public int quantity = 1;
}

[CreateAssetMenu(menuName = "GeorgeAsset/DropTable")]
public class DropTables : ScriptableObject
{
    //une liste de loots que qui peuvent apparaitre
    [SerializeField]private Loot[] loots;
    //donne un loot
    public Item[] GetItems()
    {
        //on pioche si le loot peut �tre tir� � chaque fois
        List<Item> generatedItems = new List<Item>();
        foreach (Loot loot in loots)
        {
            float drawn = Random.Range(0f, 100f);
            if (loot.Chance >= drawn)
            {
                if (loot.item != null)
                    for(int i =0;i<loot.quantity;i++)
                        generatedItems.Add(loot.item);
                else
                    Debug.Log("item not found");
            }
        }
        return generatedItems.ToArray();
    }
}
