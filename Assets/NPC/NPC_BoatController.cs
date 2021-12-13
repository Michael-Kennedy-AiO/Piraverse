using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_BoatController : MonoBehaviour{
    
    [SerializeField] float boatSpeed;
    private Vector3 firstPosition;
    private bool hit;

    private void Awake() {
        firstPosition = gameObject.transform.position;
    }

    private void Update() {
        gameObject.transform.position += Vector3.forward;
    }



}
