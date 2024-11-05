using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeContainer : MonoBehaviour
{
    public string time;
    public string bestTime;

    public void AddTime(string timeGame)
    {
        time = timeGame;
    }
    public void BestTime()
    {
        bestTime = time;
    }
}
