using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StorylineController : MonoBehaviour
{
    // Referance to scenes class and Unity text controller
    public TextMeshProUGUI text;
    public StorylineClass storyline;

    // Storyline variables 
    private string _text1 = "You are Dale, Dale lives in Detroit, Dale needs to get home from work with all the money he made. Simple.";
    private string _text2 = "Lester is calling.'The IRS will be at your place soon, destroy the evidence'...Dave needs to get home quickly...";
    private int _delay = 10;


    // Getters for storyline information
    public string GetText1() {
        return this._text1;
    }
    public string GetText2() {
        return this._text2;
    }
    public int GetDelay() {
        return this._delay;
    }

    // Connection to StoryLineClass
    void Start()
    {
        storyline = GetComponent<StorylineClass>();
    }

}
