using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimerManager : MonoBehaviour
{
    private HealthController healthController;
    private TimerManager timerManager;
    // Start is called before the first frame update
    void Start()
    {
        healthController = FindObjectOfType<HealthController>();
        timerManager = FindObjectOfType<TimerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthController != null && healthController.gameOver)
        {
            if (timerManager != null)
            {
                timerManager.PauseTimer();
                this.enabled = false;
            }
        }


    }
}
