using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController1 : MonoBehaviour{
    [Header("Player Component")]
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask layerMask;
    public static bool communicating;
    //[SerializeField] GameObject worldView;

    const float speed = 0.025f;
    bool onGround;
    Vector3 movement;
    Vector3 dir;
    
    private void Start() {
        onGround = true;
    }

    private void FixedUpdate() {
        
        if (communicating){
            this.animator.SetFloat("Horizontal", 0f);
            this.animator.SetFloat("Vertical", 0f);
            return;
        }
            
        HandleMovement();
        //HandleJump();
        
        /*if (!worldView.activeSelf){
            HandleMovement();
            HandleJump();
        }*/
    }

    private void HandleMovement(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = (this.transform.forward * vertical + this.transform.right * horizontal);
        movement.y = 0;
        movement.Normalize();

        /*if (Input.GetKey(KeyCode.LeftShift)){
            if (vertical > 0){
                this.animator.SetFloat("Horizontal", horizontal*2);
                this.animator.SetFloat("Vertical", vertical*2);
                this.transform.position += new Vector3(movement.x, 0, movement.z) * speed*2.5f;
            }else{
                this.animator.SetFloat("Horizontal", horizontal);
                this.animator.SetFloat("Vertical", vertical);
                this.transform.position += new Vector3(movement.x, 0, movement.z) * speed;
            }
        }else{
            this.animator.SetFloat("Horizontal", horizontal);
            this.animator.SetFloat("Vertical", vertical);
            this.transform.position += new Vector3(movement.x, 0, movement.z) * speed;
        }*/

        /*if (movement.magnitude != 0){
            this.animator.SetFloat("Horizontal", horizontal);
            this.animator.SetFloat("Vertical", vertical);
            this.transform.position += movement * speed;
        }*/


        this.animator.SetFloat("Horizontal", horizontal);
        this.animator.SetFloat("Vertical", vertical);


        if (Input.GetKey(KeyCode.LeftShift))
            this.transform.position += new Vector3(movement.x, 0f, movement.z) * speed*2;    
        else
            this.transform.position += new Vector3(movement.x, 0f, movement.z) * speed;
    }

    private void HandleJump(){
        GroundCheck();
        if (Input.GetKey(KeyCode.Space) && onGround){
            this.rb.AddForce(Vector3.up*5, ForceMode.Impulse);
        }
    }

    private void GroundCheck(){
        if (Physics.CheckSphere(this.transform.position, 0.2f, layerMask))
            onGround = true;
        else
            onGround = false;

        this.animator.SetBool("Jump", onGround);
    }


}
