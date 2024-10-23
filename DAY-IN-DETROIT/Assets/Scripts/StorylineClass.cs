using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StorylineClass : MonoBehaviour
{
    public TextMeshProUGUI text;
    public StorylineController storylineText;

    //Add if scene != main menu
    private string _storyText1;
    private string _storyText2;
    private int _delay;

    public void SetText1(string text) {
        this._storyText1 = text;
        Debug.Log("Text1 made");
    }
    public void SetText2(string text) {
        this._storyText2 = text;
        Debug.Log("Text2 made");
        Debug.Log(this._storyText2);
    }
    public void SetDelay(int delay) {
        this._delay = delay;
    }
    public void RunStoryLine() {
        StartCoroutine(TextOutputAndDelay());
        Debug.Log("Wokring");
    }

    // Make this into a function that runs when the controller tells it to
    void Start()
    {
        this._storyText1 = "You are Dale, Dale lives in Detroit, Dale needs to get home from work with all the money he made. Simple..";
        this._storyText2 = "Lester is calling.\r\n“The IRS will be at your place soon, destroy the evidence”...\r\nDave needs to get home quickly..\r\n";

        Debug.Log("Class running");
        text.text = " ";
        Debug.Log("Class running");
        StartCoroutine(TextOutputAndDelay());
    }

    //this._delay = 2;
    
    public IEnumerator TextOutput(string storyText){
        for (int i = 0; i < storyText.Length; i++) {
            yield return new WaitForSeconds(0.05f);
            text.text = storyText.Substring(0, i);
        }
        yield return new WaitForSeconds(3);
        text.text = "";

    }
    public IEnumerator TextSecDelay(int delay) {
        yield return new WaitForSeconds(delay);
    }
    public IEnumerator TextOutputAndDelay()
    {
        yield return StartCoroutine(TextOutput(this._storyText1));
        yield return StartCoroutine(TextSecDelay(this._delay));
        yield return StartCoroutine(TextOutput(this._storyText2));
        yield return StartCoroutine(TextSecDelay(this._delay));
    }
}
