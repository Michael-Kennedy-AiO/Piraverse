using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_ViewController1 : MonoBehaviour{
    
    private float horizontalRotate;
    private float verticalRotate;
    [SerializeField] float sensitive;
    public GameObject character;

    [Header("Camera")]
    public GameObject vrView;
    public GameObject backSideView;
    public GameObject thirdView;

    float counter;
    bool abletomove;

    private void Start() {

        vrView.transform.localRotation = Quaternion.Euler(6f, 0f, 0f);

        horizontalRotate = vrView.transform.localEulerAngles.x;
        verticalRotate = vrView.transform.localEulerAngles.y;
        sensitive = 100f;
    }

    private void Update() {
        
        if (!abletomove){
            counter += Time.deltaTime;
            if (counter >= 1.5f)
                abletomove = !abletomove;
        }

        if (CharacterController.communicating)
            return;

        CameraManager();
        if (backSideView.activeSelf)
            return;
        else
            CameraController();       
    }

    private void CameraController(){
        float mouseHorizontal = Input.GetAxis("Mouse X");
        float mouseVertical = Input.GetAxis("Mouse Y");

        horizontalRotate += mouseHorizontal * sensitive * Time.deltaTime;
        verticalRotate += mouseVertical * sensitive *- Time.deltaTime;

        verticalRotate = Mathf.Clamp(verticalRotate, -80f, 50f);

        vrView.transform.localRotation = Quaternion.Euler(verticalRotate, 0f, 0f);
        character.transform.rotation = Quaternion.Euler(0f, horizontalRotate, 0f);
    }

    private void CameraManager(){
        if (Input.GetKey(KeyCode.Alpha1)){
            vrView.SetActive(true);
            backSideView.SetActive(false);
            thirdView.SetActive(false);
        }else if(Input.GetKey(KeyCode.Alpha2)) {
            vrView.SetActive(false);
            backSideView.SetActive(true);
            thirdView.SetActive(false);
        }else if (Input.GetKey(KeyCode.Alpha3)){
            vrView.SetActive(false);
            backSideView.SetActive(false);
            thirdView.SetActive(true);
        }
    }

}
