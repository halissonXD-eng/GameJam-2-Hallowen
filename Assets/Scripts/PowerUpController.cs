using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private HealthController playerHealth;
    private SlideLifeController slideLife;
    private GameObject slider;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthController>();
        slider = GameObject.FindGameObjectWithTag("Slider");
        slideLife = slider.GetComponent<SlideLifeController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            playerHealth.health = playerHealth.maxHealth;
            slideLife.SetActualLife(playerHealth.health);
            Destroy(gameObject);
        }

    }

    
    
}
