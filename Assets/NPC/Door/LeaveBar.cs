using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBar : MonoBehaviour{
    [SerializeField] Animator rightDoor;
    [SerializeField] Animator leftDoor;

    private void OnCollisionEnter(Collision other) {
        rightDoor.Play("Leave");
        leftDoor.Play("Leave");
    }
}
