using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Manager : MonoBehaviour{
    
    [SerializeField] Animator animator;
    [SerializeField] GameObject uiPannel;

    private bool trigger;

    private void Update() {
        if (!trigger){
            return;
        }else{
            ProcessTrigger();
        }
    }


    private void ProcessTrigger(){
        if (Input.GetKeyDown(KeyCode.Space)){
            CharacterController.communicating = true;
            uiPannel.SetActive(true);
        }

        /*if (Input.GetKey(KeyCode.Escape)){
            uiPannel.SetActive(false);
        }*/
    }


    private void OnTriggerEnter(Collider other) {
        trigger = !trigger;
        animator.SetBool("Trigger",trigger);
    }


    private void OnTriggerExit(Collider other) {
        trigger = !trigger;
        animator.SetBool("Trigger",trigger);
    }
}
