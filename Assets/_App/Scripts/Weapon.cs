using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "batiment")
        {
            collision.gameObject.GetComponent<Batiment>().Chip(damage);
        }
    }
}
