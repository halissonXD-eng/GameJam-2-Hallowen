using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : GameManager
{
   
    [SerializeField] int score;

    public TextMeshProUGUI textScore;

    void Start()
    {
        AddScore(0);
    }
    void Update()
    {
        textScore.text = GetScore();
    }
    public void AddScore(int scoreValue)
    {
        score += scoreValue;
    }

    public string GetScore()
    {
        return score.ToString();
    }
}
