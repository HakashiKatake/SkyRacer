using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{   
    public static GameManager instance;
    public bool gameStarted;
    public GameObject platformspawner;
    public GameObject gamePlayUI;
    public GameObject menuPlayUI;
    public Text highScoreText;
    public Text scoreText;
    int score = 0;
    int highscore;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "HighScore:" + highscore;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
       }
    }

    public void GameStart()
    {
        gameStarted = true;
        platformspawner.SetActive(true);
        menuPlayUI.SetActive(false);
        gamePlayUI.SetActive(true);
        
        //StartCoroutine(UpdateScore());
    }

    public void GameOver() 
    {
        
        platformspawner.SetActive(false);
        StopCoroutine("UpdateScore");
        SaveHighScore();
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void IncrementScore()
    {
        score += 2;
        scoreText.text = score.ToString();
    }

    void SaveHighScore()
    {
       if(PlayerPrefs.HasKey("HighScore"))
       {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
       }
       else{
        PlayerPrefs.SetInt("HighScore", score);
       }
    }
}
