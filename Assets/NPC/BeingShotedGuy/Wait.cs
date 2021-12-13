using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour{
    float counter;
    public bool abletoPlay;
    [SerializeField] Animator anim;

    void Update(){
        if (abletoPlay){
            counter += Time.deltaTime;
            if (counter >= 1.55f){
                anim.Play("Falling Back Death");
                Destroy(gameObject.GetComponent<Wait>());
            }
        }
    }
}
