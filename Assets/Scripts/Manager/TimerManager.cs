using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float timeElapsed = 0;
    private bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        timerIsRunning = true;
    }
    private void Update()
    {
        if (timerIsRunning)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerText();
        }
    }
    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60); 
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    public void PauseTimer()
    {
        timerIsRunning = false;
    }

}
