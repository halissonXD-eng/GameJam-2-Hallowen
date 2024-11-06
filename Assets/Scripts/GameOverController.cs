using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject MenuGameOver;
    private HealthController playerHealth;
    // Score
    private ScoreGame score;
    [SerializeField] private TextMeshProUGUI textScore;

    //Timer
    TimerManager timeContainer;
    [SerializeField] private TextMeshProUGUI timerText;

    // Round 
    RoundManager roundContainer;
    [SerializeField] private TextMeshProUGUI textRound;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
        playerHealth.playerDeath += MenuActive;
        score = GameObject.Find("DataManager").GetComponent<ScoreGame>();
        textScore = textScore.GetComponent<TextMeshProUGUI>();

        
        timeContainer = GameObject.Find("DataManager").GetComponent<TimerManager>();
        timerText = timerText.GetComponent<TextMeshProUGUI>();

        roundContainer = GameObject.Find("DataManager").GetComponent<RoundManager>();
        textRound = textRound.GetComponent<TextMeshProUGUI>();
    }

    private void MenuActive(object sender, EventArgs e)
    {
        MenuGameOver.SetActive(true);
        Time.timeScale = 0f;  
        // Text Score
        score.SaveBestScore();
        textScore.text = score.BestScore.ToString();
        Debug.Log(textScore.text);

        // Text Time
        timeContainer.BestTime();
        timerText.text = timeContainer.bestTime.ToString();
        Debug.Log(timerText.text);

        // Text Round
        roundContainer.SaveBestRound();
        textRound.text = roundContainer.bestRound.ToString();
        Debug.Log(textRound.text);
    }
    public void Restart()
    {
        GameManager.Instance.SceneChange(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        GameManager.Instance.SceneChange("Menu");
        Time.timeScale = 1f;
    }

    
}
