using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField] public float maxHealth;
    public float health;
    public bool dieEnemy;

    ScoreManager score;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void GetHurt(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            if(gameObject.CompareTag("Enemy"))
            {
                gameObject.SetActive(false);
                score.AddScore(25);
                health = maxHealth;
            } else if(gameObject.CompareTag("Boss"))
            {
                gameObject.SetActive(false);
                score.AddScore(50);
                health = maxHealth;
            }
            
            if(gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
