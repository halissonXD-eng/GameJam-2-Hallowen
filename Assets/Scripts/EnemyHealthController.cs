using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
   
    [SerializeField] public float maxHealth;
    public float health;
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
                score.AddScore(25);
                gameObject.SetActive(false);
                health = maxHealth;
            } else if(gameObject.CompareTag("Boss"))
            {
                score.AddScore(50);
                gameObject.SetActive(false);
                health = maxHealth;
            }
        }
    }

    
}
