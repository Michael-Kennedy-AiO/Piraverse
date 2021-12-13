using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_Pannel : MonoBehaviour{

    public bool ableToContinue, askForConverstation, newConverstation;    
    [SerializeField] TextWriter writer;
    [SerializeField] GameObject NPC_Talk;
    [SerializeField] Text uiText;
    [SerializeField] GameObject communicate;
    public Animator player;

    public Action onClose;

    private void Start() {
        // Test Action
        /*onClose = () => {
            Debug.Log("a");
        };

        onClose = Leave;*/
        
    }

    private void Awake() {
        askForConverstation = true;
        ableToContinue = true;
        newConverstation = true;
    }



    private void Update() {
        
        /*if (ableToContinue){
            if (newConverstation){
                ShowTextCommunicate(1);
                newConverstation = false;
            }else{
                if (Input.GetMouseButtonDown(0)){
                    if (askForConverstation){
                        communicate.SetActive(true);
                        NPC_Talk.SetActive(false);
                        //ableToContinue = false;
                        //askForConverstation = false;
                    }
                }
            }

        }else
            return;*/


        if (ableToContinue){
            if (newConverstation){
                ShowTextCommunicate(1);
                newConverstation = false;
            }else if (askForConverstation){
                if (Input.GetMouseButtonDown(0)){
                    communicate.SetActive(true);
                    NPC_Talk.SetActive(false);
                    /*ableToContinue = false;
                    askForConverstation = false;*/
                }
            }

       }else
            return;

        /*if (NPC_Talk.activeSelf){
            ProcessCommunicate(0);
            
        }
        
        if (Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("a");
            StartCoroutine(OnShowChoosePannel());
            
            //gameObject.SetActive(false);
        }*/

    }

    public void OnCliockViewBalance(){
        
        communicate.SetActive(false);
        NPC_Talk.SetActive(true);
        StartCoroutine(OnShowPannel(4));
    }

    public void OnClickViewDrink(){
        NPC_Talk.SetActive(true);
        communicate.SetActive(false);
        StartCoroutine(StartDrink());
        Leave();
    }

    public void OnClickLeave(){
        NPC_Talk.SetActive(true);
        ShowTextCommunicate(3);
        communicate.SetActive(false);
        newConverstation = true;
        //if (ableToContinue)
        CharacterController.communicating = false;
        gameObject.SetActive(false);
        //Leave();
    }


    public IEnumerator OnShowPannel(int npc_Text_Index){
        ShowTextCommunicate(npc_Text_Index);

        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Stop Coroutine");
            //StopCoroutine(OnShowPannel(5));
            yield break;
        }
    }

    public IEnumerator StartDrink(){
        // => StartCoroutine(OnShowPannel(2));
        player.Play("Drink");
        //gameObject.SetActive(false);
        yield return new WaitForSeconds(8.5f);
        player.Play("Movement");
        yield break;
    }
    
    private void Leave(){
        newConverstation = true;
        CharacterController.communicating = false;
        if (ableToContinue)
            gameObject.SetActive(false);
    }

    /*private void ProcessCommunicate(int npc_Text_Index){
        if (ableToContinue){
            ableToContinue = false;
            writer.isDone = false;
            writer.AddWriter(uiText, NPC_Text.getText(npc_Text_Index));
            if (writer.isDone){
                ableToContinue = true;
                NPC_Talk.SetActive(false);
                //communicate.SetActive(true);
            }
        }
    }*/

    public void ShowTextCommunicate(int _NPC_Index){
        //if (ableToContinue){
            ableToContinue = false;
            writer.isDone = false;
            writer.AddWriter(uiText, NPC_Text.getText(_NPC_Index));
            ableToContinue = true;
        //}
    }
}
