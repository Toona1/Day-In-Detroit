using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = " ";
        string storyText = "You are Dale, Dale lives in Detroit, Dale needs to get home from work with all the money he made. Simple.";
        StartCoroutine(TextOutput(storyText));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TextOutput(string storyText){
        for (int i = 0; i < storyText.Length; i++) {
            yield return new WaitForSeconds(0.1f);
            text.text = storyText.Substring(0, i);
        }
    }
}
