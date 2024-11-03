using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RoundManager : MonoBehaviour
{
    public int round = 1;
    public TextMeshProUGUI textRound;

    public void UpdateRound()
    {
        round++;
        textRound.text = round.ToString();
    }
}
