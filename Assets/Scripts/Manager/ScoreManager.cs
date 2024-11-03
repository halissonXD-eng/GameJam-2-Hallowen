using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   
    [SerializeField] int score;

    public TextMeshProUGUI textScore;

    void Start()
    {
        AddScore(0);
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        textScore.text = score.ToString();
        Debug.Log(score);
    }

}
