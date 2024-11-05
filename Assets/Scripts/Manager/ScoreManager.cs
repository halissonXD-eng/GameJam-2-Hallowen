using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   
    public int score;

    int BestScore;

    void Start()
    {
        AddScore(0);
    }
    
    public void AddScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void SaveBestScore()
    {
        BestScore = score;
    }

}
