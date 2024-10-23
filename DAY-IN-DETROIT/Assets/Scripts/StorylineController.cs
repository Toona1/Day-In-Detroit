using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorylineController : MonoBehaviour
{
    public StorylineClass storyline;
    // Start is called before the first frame update
    void Start()
    {
        storyline = GetComponent<StorylineClass>();
        storyline.SetText1("You are Dale, Dale lives in Detroit, Dale needs to get home from work with all the money he made. Simple..");
        storyline.SetText2("Lester is calling.\r\n“The IRS will be at your place soon, destroy the evidence”...\r\nDave needs to get home quickly..\r\n");
        storyline.SetDelay(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
