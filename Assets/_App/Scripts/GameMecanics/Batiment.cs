using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batiment : MonoBehaviour
{
    [SerializeField]private float health;
    void Update ()
    {
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void Chip(int damage)
    {
        health -= damage;
    }
}
