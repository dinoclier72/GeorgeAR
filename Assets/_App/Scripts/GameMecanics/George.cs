using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class George : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    private bool attacking = false;
    private Batiment batiment;

    // Update is called once per frame
    void Update()
    {
        if(attacking){
            playerAnimator.SetBool("attacking", true);
            if(batiment == null){
                attacking = false;
                playerAnimator.SetBool("attacking", false);
            }
        }
        else{
            playerAnimator.SetBool("attacking", false);
        }
    }

    void OnTriggerStay(Collider other){
        //detruire le batiment
        if(other.tag == "batiment"){
            transform.LookAt(other.transform.position);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            attacking = true;
            batiment = other.GetComponent<Batiment>();
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "batiment"){
            attacking = false;
        }
    }
}
