using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lives : MonoBehaviour
{
    [SerializeField]
    private GameObject life1, life2, life3;
    public int lives;

    public Scenes scenesScript;


    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        // StartCoroutine(UpdateLives());
    }


    IEnumerator UpdateLives()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (lives <= 2)
            {
                Destroy(life3);
            }
            if (lives <= 1)
            {
                Destroy(life2);
            }
            if (lives <= 0)
            {
                Destroy(life1);
                scenesScript.PlayerDeath();
            }

        }

    }


    // Update is called once per frame
    void Update()
    {
        if (lives <= 2)
        {
            Destroy(life3);
        }
        if (lives <= 1)
        {
            Destroy(life2);
        }
        if (lives <= 0)
        {
            Destroy(life1);
            scenesScript.PlayerDeath();
        }
    }
}
