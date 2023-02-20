using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private int score = 0;
    
    //public int score = 0;
    
    //Text
    public TextMeshPro textMeshPro;//can see outside the script
    
    //Sava Data
    const string DIR_DATA = "/Data/";
    const string FILE_HIGH_SCORE = "highScore.text";
    string PATH_HIGH_SCORE;
    
    public const string PREF_HIGH_SCORE = "hsScore";//const dont change & plz all CAPs 

    public int Score
    {
        get { return score;} //get the value out
        set
        {
            score = value;
            //Debug.log("THE SCORE CHANGED!");
            if (score > HighScore)
            {
                HighScore = score;
            }
        }
    }

    int highScore = 2;//defaultValue

    public int HighScore
    {
        get
        {
            //highScore = PlayerPrefs.GetInt(PREF_HIGH_SCORE, 2);
            return highScore;
        }
        set
        {
            highScore = value;
            Directory.CreateDirectory(Application.dataPath + DIR_DATA);
            File.WriteAllText(PATH_HIGH_SCORE, "" + highScore);
            //PlayerPrefs.SetInt(PREF_HIGH_SCORE, highScore);
        }
    }
    
    public int currentLevel = 0;

    public int targetScore = 2;

    private void Awake()
    {
        if (Instance == null) //Instance has not been set
        {
            DontDestroyOnLoad(gameObject); //dont destroy
            Instance = this; //and set instance to this GameManager
        }
        else //Instance is set
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PATH_HIGH_SCORE = Application.dataPath + DIR_DATA + FILE_HIGH_SCORE;
        if(File.Exists(PATH_HIGH_SCORE))
        {
            HighScore = Int32.Parse(File.ReadAllText(PATH_HIGH_SCORE));
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (score == targetScore) //if we hit the target score
        {
            currentLevel++; //increase the level
            targetScore = targetScore * 2; //increase the target
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel); //go to the next level
        }
        
        //remove high score
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //PlayerPrefs.DeleteKey(PREF_HIGH_SCORE);
            //File.WriteAllText(PATH_HIGH_SCORE, "2");
            //File.Delete(PATH_HIGH_SCORE);
        }
        textMeshPro.text =
            "Level: " + (currentLevel+1) + "\n" + 
            "Score: " + score + "\n" +
            "High Score: " + HighScore;

        // if (score <= -1)
        // {
        //     UnityEngine.SceneManagement.SceneManager.LoadScene("End");
        // }

    }
    
    
}
