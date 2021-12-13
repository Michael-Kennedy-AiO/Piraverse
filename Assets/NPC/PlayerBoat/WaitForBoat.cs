using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForBoat : MonoBehaviour{

    float counter;


    //[SerializeField] GameObject parent;
    Vector3 currentPos;


    private void Start() {
        //currentPos = gameObject.transform.position;
        
    }

    private void FixedUpdate() {
    
    }

    private void Update() {
        //parent.transform.position = gameObject.transform.position;
        counter += Time.deltaTime;
        

        if (counter >= 7f)
            Destroy(gameObject.GetComponent<WaitForBoat>());

        //currentPos = gameObject.transform.position;
    }
}
