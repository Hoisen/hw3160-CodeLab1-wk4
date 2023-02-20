using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class TestMusic : MonoBehaviour
{
    
    //Level0 ends in 10 secs
    public int gameLength = 10;
    public float timer = 0;
    public TextMeshPro displayText;

    private bool inLevel0 = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inLevel0)
        {
            timer += Time.deltaTime;
            displayText.text =
                "Timer: " + (gameLength - (int)timer) + "\n";
        }

        if (timer >= gameLength && inLevel0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // if (col.gameObject.tag == "Player")
        // {
        //     UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        // }
    }
}
