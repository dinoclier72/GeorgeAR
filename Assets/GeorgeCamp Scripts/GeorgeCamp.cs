using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeorgeCamp : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private Animator playerAnimator;
    private bool Chopping;
    private bool attacking;
    private Tree tree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destruction de l'arbre
        if(Chopping)
        {
            playerAnimator.SetBool("hitting", true);
            if (!attacking)
            {
                attacking = true;
                Invoke("hit", 4);
            }
            if(tree == null)
            {
                Chopping = false;
            }
        }
        else
        {
            playerAnimator.SetBool("hitting", false);
        }
        
    }

    void hit()
    {
        //taper l'arbre
        tree.chop(damage);
        attacking = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        //ramasser l'item
        if(collision.tag == "item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            item.pickup();
        }
    }
    void OnTriggerStay(Collider other)
    {
        //couper l'arbre
        if (other.tag == "tree")
        {
            tree = other.gameObject.GetComponent<Tree>();
            transform.LookAt(tree.transform);
            Chopping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //arreter de couper l'arbre
        if(other.tag == "tree")
        {
            Chopping = false;
        }
    }
}
