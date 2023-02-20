using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class playerName : MonoBehaviour
{
    public static playerName Instance;

    private bool gotName = false;
    
    public TextMeshPro textMeshPro;
    public TextMeshPro endText;

     string name;
     
     //string input;
    
     //name
     //Sava Data
     // const string DIR_DATA = "/Data/";
    // const string FILE_PLAYER_NAME = "playerName.text";
    // string PATH_PLAYER_NAME;
    // public const string PREF_PLAYER_NAME = "pName";
    
    

    
    public string Name
    {
        get
        {
            name = PlayerPrefs.GetString("PlayerName");
            return name; 
        }
        set
        {
            name = value;
            PlayerPrefs.SetString("PlayerName", name);
            // Directory.CreateDirectory(Application.dataPath + DIR_DATA);
            // File.WriteAllText(PATH_PLAYER_NAME, "" + name);
        }
    }
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        name = PlayerPrefs.GetString("PlayerName");
        endText.text = Name + " - " + GameManager.Instance.Score;
        
    }

    public void readStringInput(string playerName)
    {
        Name = playerName;
        PlayerPrefs.SetString("PlayerName", Name);
        //Debug.Log(input);
        Debug.Log(Name);
        gotName = true;
        
        if (gotName == true)
        {
            textMeshPro.text =
                "Welcome, " + Name + "!";
            StartCoroutine(TestCoroutine());
        }
    }
    

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level0");
    }
    
}
