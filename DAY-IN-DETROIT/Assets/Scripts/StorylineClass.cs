using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class StorylineClass : MonoBehaviour
{
    // Referance to scenes class and Unity text controller
    public TextMeshProUGUI text;
    public StorylineController storylineText;

    //Storyline varibales
    private string _storyText1;
    private string _storyText2;
    private int _delay;

    // Builds variables (sort of constructor)
    public StorylineClass(string text1, string text2, int delay) {
        this._storyText1 = text1;
        this._storyText2 = text2;
        this._delay = delay;
    }

    // Getters and setters for texts and delay
    public void SetText1(string text) {
        this._storyText1 = text;
    }
    public string GetText1() {
        return this._storyText1;
    }
    public void SetText2(string text) {
        this._storyText2 = text;
    }
    public string GetText2() {
        return this._storyText2;
    }
    public void SetDelay(int delay) {
        this._delay = delay;
    }

    // Coroutines regulating the output of text
    public IEnumerator TextOutput(string storyText)
    {
        for (int i = 0; i < storyText.Length; i++)
        {
            yield return new WaitForSeconds(0.05f);
            text.text = storyText.Substring(0, i);
        }
        yield return new WaitForSeconds(3);
        text.text = "";

    }
    // Delay between stoyline text
    public IEnumerator TextSecDelay(int delay)
    {
        yield return new WaitForSeconds(delay);
    }

    // Runs coroutines one at a time
    public IEnumerator TextOutputAndDelay()
    {
        yield return StartCoroutine(TextOutput(this._storyText1));
        yield return StartCoroutine(TextSecDelay(this._delay));
        yield return StartCoroutine(TextOutput(this._storyText2));
        yield return StartCoroutine(TextSecDelay(this._delay));
    }

    // Gets and sets values 
    void Start()
    {
        storylineText = GetComponent<StorylineController>();
        SetText1(storylineText.GetText1());
        SetText2(storylineText.GetText2());
        SetDelay(storylineText.GetDelay());
        text.text = " ";
        StartCoroutine(TextOutputAndDelay());
    }



}
