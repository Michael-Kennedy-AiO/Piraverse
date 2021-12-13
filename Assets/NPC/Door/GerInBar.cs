using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerInBar : MonoBehaviour{
    
    [SerializeField] Animator rightDoor;
    [SerializeField] Animator leftDoor;

    [SerializeField] Wait wait;
    [SerializeField] Paragel paragel;

    private void OnTriggerEnter(Collider other){
        rightDoor.Play("GetInR");
        leftDoor.Play("GetInL");
        wait.abletoPlay = true;
        paragel.abletoPlay = true;
        Destroy(gameObject.GetComponent<GerInBar>());
    }

}
