using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StorylineClass : MonoBehaviour
{
    public TextMeshProUGUI text;

    private string _storyText1;
    private string _storyText2;
    private int _delay;

    public void SetText1(string text) {
        this._storyText1 = text;
    }
    public void SetText2(string text) {
        this._storyText2 = text;
    }
    public void SetDelay(int delay) {
        this._delay = delay;
    }
    public void RunStoryLine() {
        StartCoroutine(TextOutputAndDelay());
        Debug.Log("Wokring");
    }

    // Start is called before the first frame update
    void Start()
    {
        text.text = " ";
        this._delay = 2;
        this._storyText1 = "You are Dale, Dale lives in Detroit, Dale needs to get home from work with all the money he made. Simple..";
        this._storyText2 = "Lester is calling.\r\n“The IRS will be at your place soon, destroy the evidence”...\r\nDave needs to get home quickly..\r\n";

        StartCoroutine(TextOutputAndDelay());

    }



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
