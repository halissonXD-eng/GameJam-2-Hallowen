using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundContainer : MonoBehaviour
{
    int round;
    int bestRound;

    public void addRound()
    {
        round++;
    }
    public void SaveBestRound()
    {
        bestRound = round;
    }
}
