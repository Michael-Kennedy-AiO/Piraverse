using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paragel : MonoBehaviour{
    public bool abletoPlay, startcount;
    [SerializeField] Animator anim;
    float counter;


    void Update(){
        if (abletoPlay){
            anim.Play("ParagelShut");
            abletoPlay = !abletoPlay;
            startcount = true;
        }

        if (startcount)
            counter += Time.deltaTime;

        if (Time.deltaTime >= 2.11f){
            anim.Play("StandingTalk");
            Destroy(gameObject.GetComponent<Paragel>());
        }


    }
}
