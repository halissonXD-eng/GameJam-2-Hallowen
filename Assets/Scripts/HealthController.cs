using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    public float health;

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
            if(gameObject.CompareTag("Enemy") || gameObject.CompareTag("Boss"))
            {
                gameObject.SetActive(false);
                health = maxHealth;
            }
            
            if(gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
