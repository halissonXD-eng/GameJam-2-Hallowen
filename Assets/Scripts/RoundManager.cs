using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RoundManager : MonoBehaviour
{
    public int round = 1;
    private TextMeshProUGUI textRound;

    void Start()
    {
        textRound = GameObject.Find("Ronda").GetComponent<TextMeshProUGUI>();
        
    }
    public void UpdateRound()
    {
        round++;
        textRound.text = round.ToString();
    }
}
