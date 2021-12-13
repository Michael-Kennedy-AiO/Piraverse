using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour{

    public bool isDone;
    float countTime;
    int characterIndex;
    [SerializeField] float timePerCharacter;

    Text uiText;
    string textNeedToWriter;

    void Start(){
        timePerCharacter = 0.005f;
        countTime = 0;
    }

    public void AddWriter(Text uiText, string textNeedToWriter){
        this.uiText = uiText;
        this.textNeedToWriter = textNeedToWriter;
        characterIndex = 0;
    }

    void Update(){
        if (isDone)
            return;
        
        if (uiText != null){
            countTime += Time.deltaTime;
            if (countTime >= timePerCharacter){
                characterIndex++;
                uiText.text = textNeedToWriter.Substring(0, characterIndex);
                if (characterIndex == textNeedToWriter.Length)
                    isDone = true;
                
                
                countTime -= timePerCharacter;
            }
        }
    }
}
