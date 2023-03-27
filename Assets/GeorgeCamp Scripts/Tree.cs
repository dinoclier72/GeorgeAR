using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public DropTables dropTable;
    public bool chopped;
    public float health;
    public float itemSpawnRadius = 10;

    void Awake()
    {
        itemSpawnRadius *= transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Die();
    }

    //fonction pour quand l'abre est coup�
    void Die()
    {
        //la fonction va disperser les objets genr�s par la destruction
        Item[] itemsLooted = dropTable.GetItems();
        foreach(Item item in itemsLooted)
        {
            Instantiate(item,transform.position + new Vector3(Random.Range(-itemSpawnRadius, itemSpawnRadius),0, Random.Range(-itemSpawnRadius, itemSpawnRadius)), transform.rotation);
        }
        Destroy(gameObject);
    }

    public void chop(int damage)
    {
        health -= damage;
    }
}
