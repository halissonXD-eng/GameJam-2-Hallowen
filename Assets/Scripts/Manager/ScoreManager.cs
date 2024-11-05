using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   
    [SerializeField] int score;

    private TextMeshProUGUI textScore;

    void Start()
    {
        textScore = GameObject.Find("puntaje").GetComponent<TextMeshProUGUI>();
        AddScore(0);
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        textScore.text = score.ToString();
    }

}
