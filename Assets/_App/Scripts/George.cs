using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class George : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    private bool attacking = false;

    // Update is called once per frame
    void Update()
    {
        if(attacking){
            playerAnimator.SetBool("attacking", true);
        }
        else{
            playerAnimator.SetBool("attacking", false);
        }
    }

    void OnTriggerStay(Collider other){
        //detruire le batiment
        if(other.tag == "batiment"){
            transform.LookAt(other.transform);
            attacking = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "batiment"){
            attacking = false;
        }
    }
}
