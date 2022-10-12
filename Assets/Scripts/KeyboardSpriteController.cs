using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSpriteController : MonoBehaviour
{
    public Typer typer = null;
    public Timer timer = null;

    public GameObject parent;
    public Sprite keyIdleSprite;
    public Sprite keyActiveSprite;
    public Sprite keyWrongSprite;
    public Sprite keyEnterSprite;
    public Sprite keyEnterWrongSprite;
    public Sprite keySpaceSprite;
    public Sprite keySpaceActiveSprite;
    public Sprite keySpaceWrongSprite;
    public Sprite keyTabSprite;
    public Sprite keyTabWrongSprite;
    public Sprite keyCapsSprite;
    public Sprite keyCapsWrongSprite;
    public Sprite keyLshiftSprite;
    public Sprite keyLshiftActiveSprite;
    public Sprite keyLshiftWrongSprite;
    public Sprite keyRshiftSprite;
    public Sprite keyRshiftActiveSprite;
    public Sprite keyRshiftWrongSprite;
    public Sprite keyBottomMostSprite;
    public Sprite keyBottomMostWrongSprite;
    
    string activeKey;
    string activeKeyHelper;
    string wrongKey;

    void Start()
    {
        if(!PrefVariables.isKeyboardOn)
            parent.SetActive(false);
    }

    void Update()
    {
        ChangeSprite();
    }

    void ChangeSprite()
    {
        activeKey = typer.ActiveLetter;
        wrongKey = typer.WrongLetter;
        if(PrefVariables.isGameRun && timer.startTime == 0 && activeKey != string.Empty)
        {
            if(activeKeyHelper != activeKey){
                activeKeyHelper = activeKey;
                for(int i = 0; i < 48; i++)
                {
                    parent.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = keyIdleSprite;
                }
                parent.transform.GetChild(48).gameObject.GetComponent<SpriteRenderer>().sprite = keyEnterSprite;
                parent.transform.GetChild(49).gameObject.GetComponent<SpriteRenderer>().sprite = keySpaceSprite;
                parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftSprite;
                parent.transform.GetChild(53).gameObject.GetComponent<SpriteRenderer>().sprite = keyRshiftSprite;
                
                if(activeKey[0]-'a' >= 0 && activeKey[0]-'a' <= 25)
                    parent.transform.GetChild(activeKey[0]-'a').gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "`")
                    parent.transform.GetChild(26).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "~"){
                    parent.transform.GetChild(26).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(53).gameObject.GetComponent<SpriteRenderer>().sprite = keyRshiftActiveSprite;
                }
                else if(activeKey == "1")
                    parent.transform.GetChild(27).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "!"){
                    parent.transform.GetChild(27).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(53).gameObject.GetComponent<SpriteRenderer>().sprite = keyRshiftActiveSprite;
                }
                else if(activeKey == "2")
                    parent.transform.GetChild(28).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "@"){
                    parent.transform.GetChild(28).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(53).gameObject.GetComponent<SpriteRenderer>().sprite = keyRshiftActiveSprite;
                }
                else if(activeKey == "3")
                    parent.transform.GetChild(29).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "#"){
                    parent.transform.GetChild(29).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(53).gameObject.GetComponent<SpriteRenderer>().sprite = keyRshiftActiveSprite;
                }
                else if(activeKey == "4")
                    parent.transform.GetChild(30).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "$"){
                    parent.transform.GetChild(30).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(53).gameObject.GetComponent<SpriteRenderer>().sprite = keyRshiftActiveSprite;
                }
                else if(activeKey == "5")
                    parent.transform.GetChild(31).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "%"){
                    parent.transform.GetChild(31).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(53).gameObject.GetComponent<SpriteRenderer>().sprite = keyRshiftActiveSprite;
                }
                else if(activeKey == "6")
                    parent.transform.GetChild(32).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "^"){
                    parent.transform.GetChild(32).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == "7")
                    parent.transform.GetChild(33).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "&"){
                    parent.transform.GetChild(33).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == "8")
                    parent.transform.GetChild(34).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "*"){
                    parent.transform.GetChild(34).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == "9")
                    parent.transform.GetChild(35).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "("){
                    parent.transform.GetChild(35).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == "0")
                    parent.transform.GetChild(36).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == ")"){
                    parent.transform.GetChild(36).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == "-")
                    parent.transform.GetChild(37).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "_"){
                    parent.transform.GetChild(37).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == "=")
                    parent.transform.GetChild(38).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "+"){
                    parent.transform.GetChild(38).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == "\\")
                    parent.transform.GetChild(39).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "|"){
                    parent.transform.GetChild(39).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == "[")
                    parent.transform.GetChild(40).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "{"){
                    parent.transform.GetChild(40).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == "]")
                    parent.transform.GetChild(41).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "}"){
                    parent.transform.GetChild(41).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == ";")
                    parent.transform.GetChild(42).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == ":"){
                    parent.transform.GetChild(42).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == "'")
                    parent.transform.GetChild(43).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "\""){
                    parent.transform.GetChild(43).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == ",")
                    parent.transform.GetChild(44).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "<"){
                    parent.transform.GetChild(44).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == ".")
                    parent.transform.GetChild(45).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == ">"){
                    parent.transform.GetChild(45).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == "/")
                    parent.transform.GetChild(46).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                else if(activeKey == "?"){
                    parent.transform.GetChild(46).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
                    parent.transform.GetChild(52).gameObject.GetComponent<SpriteRenderer>().sprite = keyLshiftActiveSprite;
                }
                else if(activeKey == " ")
                    parent.transform.GetChild(49).gameObject.GetComponent<SpriteRenderer>().sprite = keySpaceActiveSprite;
                // GameObject childObject = parent.transform.GetChild(activeKey[0]-'a').gameObject;
                // childObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
            }

            if(wrongKey != string.Empty)
            {
                StartCoroutine(ChangeWrongSprite());
            }
            else if(typer.IsSpecialKeyPressed)
            {
                StartCoroutine(ChangeSpecialSprite());
            }
        }
    }
    
    IEnumerator ChangeWrongSprite()
    {
        typer.WrongLetter = string.Empty;
        if(wrongKey[0]-'a' >= 0 && wrongKey[0]-'a' <= 25)
            parent.transform.GetChild(wrongKey[0]-'a').gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.BackQuote))
            parent.transform.GetChild(26).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Alpha1))
            parent.transform.GetChild(27).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            parent.transform.GetChild(28).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Alpha3))
            parent.transform.GetChild(29).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Alpha4))
            parent.transform.GetChild(30).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Alpha5))
            parent.transform.GetChild(31).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Alpha6))
            parent.transform.GetChild(32).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Alpha7))
            parent.transform.GetChild(33).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Alpha8))
            parent.transform.GetChild(34).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Alpha9))
            parent.transform.GetChild(35).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Alpha0))
            parent.transform.GetChild(36).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Minus))
            parent.transform.GetChild(37).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Equals))
            parent.transform.GetChild(38).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Backslash))
            parent.transform.GetChild(39).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.LeftBracket))
            parent.transform.GetChild(40).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.RightBracket))
            parent.transform.GetChild(41).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Semicolon))
            parent.transform.GetChild(42).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Quote))
            parent.transform.GetChild(43).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Comma))
            parent.transform.GetChild(44).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Period))
            parent.transform.GetChild(45).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Slash))
            parent.transform.GetChild(46).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Backspace))
            parent.transform.GetChild(47).gameObject.GetComponent<SpriteRenderer>().sprite = keyWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Return))
            parent.transform.GetChild(48).gameObject.GetComponent<SpriteRenderer>().sprite = keyEnterWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Space))
            parent.transform.GetChild(49).gameObject.GetComponent<SpriteRenderer>().sprite = keySpaceWrongSprite;
        
        yield return new WaitForSeconds(0.1f);
        
        for(int i = 0; i < 48; i++)
        {
            parent.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = keyIdleSprite;
        }
        parent.transform.GetChild(48).gameObject.GetComponent<SpriteRenderer>().sprite = keyEnterSprite;
        parent.transform.GetChild(49).gameObject.GetComponent<SpriteRenderer>().sprite = keySpaceSprite;
        
        // parent.transform.GetChild(activeKey[0]-'a').gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        if(activeKey[0]-'a' >= 0 && activeKey[0]-'a' <= 25)
            parent.transform.GetChild(activeKey[0]-'a').gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "`" || activeKey == "~")
            parent.transform.GetChild(26).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "1" || activeKey == "!")
            parent.transform.GetChild(27).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "2" || activeKey == "@")
            parent.transform.GetChild(28).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "3" || activeKey == "#")
            parent.transform.GetChild(29).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "4" || activeKey == "$")
            parent.transform.GetChild(30).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "5" || activeKey == "%")
            parent.transform.GetChild(31).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "6" || activeKey == "^")
            parent.transform.GetChild(32).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "7" || activeKey == "&")
            parent.transform.GetChild(33).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "8" || activeKey == "*")
            parent.transform.GetChild(34).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "9" || activeKey == "(")
            parent.transform.GetChild(35).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "0" || activeKey == ")")
            parent.transform.GetChild(36).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "-" || activeKey == "_")
            parent.transform.GetChild(37).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "=" || activeKey == "+")
            parent.transform.GetChild(38).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "\\" || activeKey == "|")
            parent.transform.GetChild(39).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "[" || activeKey == "{")
            parent.transform.GetChild(40).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "]" || activeKey == "}")
            parent.transform.GetChild(41).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == ";" || activeKey == ":")
            parent.transform.GetChild(42).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "'" || activeKey == "\"")
            parent.transform.GetChild(43).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "," || activeKey == "<")
            parent.transform.GetChild(44).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "." || activeKey == ">")
            parent.transform.GetChild(45).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == "/" || activeKey == "?")
            parent.transform.GetChild(46).gameObject.GetComponent<SpriteRenderer>().sprite = keyActiveSprite;
        else if(activeKey == " ")
            parent.transform.GetChild(49).gameObject.GetComponent<SpriteRenderer>().sprite = keySpaceActiveSprite;
    }

    IEnumerator ChangeSpecialSprite()
    {
        typer.IsSpecialKeyPressed = false;
        if(Input.GetKeyDown(KeyCode.Tab))
            parent.transform.GetChild(50).gameObject.GetComponent<SpriteRenderer>().sprite = keyTabWrongSprite;
        else if(Input.GetKeyDown(KeyCode.CapsLock))
            parent.transform.GetChild(51).gameObject.GetComponent<SpriteRenderer>().sprite = keyCapsWrongSprite;
        else if(Input.GetKeyDown(KeyCode.LeftControl))
            parent.transform.GetChild(54).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostWrongSprite;
        else if(Input.GetKeyDown(KeyCode.LeftWindows))
            parent.transform.GetChild(55).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostWrongSprite;
        else if(Input.GetKeyDown(KeyCode.LeftAlt))
            parent.transform.GetChild(56).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostWrongSprite;
        else if(Input.GetKeyDown(KeyCode.RightAlt))
            parent.transform.GetChild(57).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostWrongSprite;
        else if(Input.GetKeyDown(KeyCode.RightWindows))
            parent.transform.GetChild(58).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostWrongSprite;
        else if(Input.GetKeyDown(KeyCode.Menu))
            parent.transform.GetChild(59).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostWrongSprite;
        else if(Input.GetKeyDown(KeyCode.RightControl))
            parent.transform.GetChild(60).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostWrongSprite;

        yield return new WaitForSeconds(0.1f);

        parent.transform.GetChild(50).gameObject.GetComponent<SpriteRenderer>().sprite = keyTabSprite;
        parent.transform.GetChild(51).gameObject.GetComponent<SpriteRenderer>().sprite = keyCapsSprite;
        parent.transform.GetChild(54).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostSprite;
        parent.transform.GetChild(55).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostSprite;
        parent.transform.GetChild(56).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostSprite;
        parent.transform.GetChild(57).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostSprite;
        parent.transform.GetChild(58).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostSprite;
        parent.transform.GetChild(59).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostSprite;
        parent.transform.GetChild(60).gameObject.GetComponent<SpriteRenderer>().sprite = keyBottomMostSprite;
    }
}
