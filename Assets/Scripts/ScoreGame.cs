using UnityEngine;
using TMPro;
public class ScoreGame : MonoBehaviour
{

    ScoreManager scoreManager;
    int score;
    public int BestScore;
    private TextMeshProUGUI textScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        textScore = GameObject.Find("puntaje").GetComponent<TextMeshProUGUI>();
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        textScore.text = score.ToString();
        scoreManager.AddScore(score);
    }

    public void SaveBestScore()
    {
        BestScore = score;
    }
}
