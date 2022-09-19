using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private textContainer scoreText;
    [SerializeField] private textContainer deathText;
    [SerializeField] private textContainer HighScoreText;
    [SerializeField] private FloatValue score;
    [SerializeField] private IntValue deaths;
    [SerializeField] private FloatValue highScore;




    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Start") return;
        if(SceneManager.GetActiveScene().name == "FrankenGame")
        {
            score.floatValue = 0;
            deaths.intValue = 0;
        }
        
        
        scoreText.textMeshProUGUI = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        deathText.textMeshProUGUI = GameObject.FindGameObjectWithTag("DeathText").GetComponent<TextMeshProUGUI>();
        HighScoreText.textMeshProUGUI = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<TextMeshProUGUI>();
        if (score.floatValue == 0) scoreText.textMeshProUGUI.SetText("Score: 0");
        else scoreText.textMeshProUGUI.SetText(score.floatValue.ToString("Score: ##"));
        if (highScore.floatValue == 0) HighScoreText.textMeshProUGUI.SetText("High Score: 0");
        else HighScoreText.textMeshProUGUI.SetText(highScore.floatValue.ToString("High Score: ##"));
        if (deaths.intValue == 0) deathText.textMeshProUGUI.SetText("Deaths: 0");
        else deathText.textMeshProUGUI.SetText(deaths.intValue.ToString("Deaths: ##"));



    }
    private void Update()
    {
        
    }
    private void OnEnable()
    {
        HandCollision.UpdateDeaths += UpdateDeathsText;
        PistonController.UpdateScore += UpdateScoreText;
        PistonController.LoadEndScene += LoadScene;
        HandCollision.LoadEndScene += LoadScene;
    }

    private void OnDisable()
    {
        HandCollision.UpdateDeaths -= UpdateDeathsText;
        PistonController.UpdateScore -= UpdateScoreText;
        PistonController.LoadEndScene -= LoadScene;
        HandCollision.LoadEndScene -= LoadScene;


    }
    private void UpdateScoreText(float score)
    {

        this.score.floatValue +=  score;
        scoreText.textMeshProUGUI.SetText(this.score.floatValue.ToString("Score: ##")); 
        


    }

    private void UpdateHighScoreText(float score)
    {
        if (score < highScore.floatValue || highScore.floatValue == 0)
        {
            Debug.Log(highScore.floatValue);
            highScore.floatValue = score;

            HighScoreText.textMeshProUGUI.SetText(highScore.floatValue.ToString("HighScore: ##"));
        }
    }
   
    private void UpdateDeathsText(int deaths)
    {
        this.deaths.intValue += deaths;
        deathText.textMeshProUGUI.SetText(this.deaths.intValue.ToString("Deaths: ##"));

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        if (SceneManager.GetActiveScene().name == "Start") return;
        UpdateHighScoreText(score.floatValue);
        


    }
}
