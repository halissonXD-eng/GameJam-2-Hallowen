using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RoundManager : MonoBehaviour
{
    public int round = 1;
    public int bestRound;
    private TextMeshProUGUI textRound;

    RoundContainer roundContainer;

    void Start()
    {
        textRound = GameObject.Find("Ronda").GetComponent<TextMeshProUGUI>();
        roundContainer = GameObject.Find("GameManager").GetComponent<RoundContainer>();
    }
    public void UpdateRound()
    {
        round++;
        textRound.text = round.ToString();
    }

     public void SaveBestRound()
    {
        bestRound = round;
    }
}
