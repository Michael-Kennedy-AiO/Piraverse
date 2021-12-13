using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour{
    
    [SerializeField] Animator play;

    private void OnTriggerEnter(Collider other){
        play.Play("Wheelbarrow Walk");
        Destroy(gameObject);
    }
}
