using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSpriteController : MonoBehaviour
{
    [SerializeField] Typer typer = null;
    [SerializeField] Timer timer = null;

    [SerializeField] GameObject leftHand = null;
    [SerializeField] GameObject rightHand = null;

    [SerializeField] Sprite leftHandIdle = null;
    [SerializeField] Sprite leftHandThumb = null;
    [SerializeField] Sprite leftHandIndex = null;
    [SerializeField] Sprite leftHandMiddle = null;
    [SerializeField] Sprite leftHandRing = null;
    [SerializeField] Sprite leftHandLittle = null;
    [SerializeField] Sprite rightHandIdle = null;
    [SerializeField] Sprite rightHandThumb = null;
    [SerializeField] Sprite rightHandIndex = null;
    [SerializeField] Sprite rightHandMiddle = null;
    [SerializeField] Sprite rightHandRing = null;
    [SerializeField] Sprite rightHandLittle = null;

    string activeKey;

    void Start()
    {
        if(!PrefVariables.isHandsOn)
        {
            leftHand.SetActive(false);
            rightHand.SetActive(false);
        }
        else if(!PrefVariables.isKeyboardOn && PrefVariables.isHandsOn)
        {
            leftHand.transform.position = new Vector3(-2.15f, -3.15f, 0f);
            rightHand.transform.position = new Vector3(2.15f, -3.15f, 0f);
        }
    }

    void Update()
    {
        ChangeHandSprite();
    }

    void ChangeHandSprite()
    {
        activeKey = typer.ActiveLetter;

        if(PrefVariables.isGameRun && timer.startTime == 0 && activeKey != string.Empty)
        {
            if(activeKey == "q" || activeKey == "a" || activeKey == "z" || activeKey == "1" || activeKey == "`")
            {
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandLittle;
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandIdle;
            }
            else if(activeKey == "~" || activeKey == "!"){
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandLittle;
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandLittle;
            }
            else if(activeKey == "w" || activeKey == "s" || activeKey == "x" || activeKey == "2")
            {
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandRing;
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandIdle;
            }
            else if(activeKey == "@"){
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandRing;
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandLittle;
            }
            else if(activeKey == "e" || activeKey == "d" || activeKey == "c" || activeKey == "3")
            {
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandMiddle;
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandIdle;
            }
            else if(activeKey == "#"){
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandMiddle;
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandLittle;
            }
            else if(activeKey == "r" || activeKey == "f" || activeKey == "v" || activeKey == "t" || activeKey == "g" || activeKey == "b" || activeKey == "4" || activeKey == "5")
            {
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandIndex;
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandIdle;
            }
            else if(activeKey == "$" || activeKey == "%"){
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandIndex;
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandLittle;
            }
            else if(activeKey == "y" || activeKey == "h" || activeKey == "n" || activeKey == "u" || activeKey == "j" || activeKey == "m" || activeKey == "6" || activeKey == "7")
            {
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandIndex;
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandIdle;
            }
            else if(activeKey == "^" || activeKey == "&"){
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandIndex;
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandLittle;
            }
            else if(activeKey == "i" || activeKey == "k" || activeKey == "8" || activeKey == ",")
            {
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandMiddle;
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandIdle;
            }
            else if(activeKey == "*" || activeKey == "<"){
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandMiddle;
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandLittle;
            }
            else if(activeKey == "o" || activeKey == "l" || activeKey == "9" || activeKey == ".")
            {
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandRing;
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandIdle;
            }
            else if(activeKey == "(" || activeKey == ">"){
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandRing;
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandLittle;
            }
            else if(activeKey == "p" || activeKey == "0" || activeKey == ";" || activeKey == "/" || activeKey == "-" || activeKey == "[" || activeKey == "'" || activeKey == "=" || activeKey == "]" || activeKey == "\\")
            {
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandLittle;
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandIdle;
            }
            else if(activeKey == ")" || activeKey == ":" || activeKey == "?" || activeKey == "_" || activeKey =="{" || activeKey == "\"" || activeKey == "+" || activeKey == "}" || activeKey == "|"){
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandLittle;
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandLittle;
            }
            else if(activeKey == " ")
            {
                rightHand.GetComponent<SpriteRenderer>().sprite = rightHandThumb;
                leftHand.GetComponent<SpriteRenderer>().sprite = leftHandThumb;
            }
        }
    }
}
