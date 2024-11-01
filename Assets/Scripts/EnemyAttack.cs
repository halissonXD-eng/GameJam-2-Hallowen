using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    private HealthController playerHealth;
    private EnemyMovement enemyState;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthController>();
        enemyState = GetComponent<EnemyMovement>();
        
    }

    // Update is called once per frame
   

    private void OnCollisionEnter2D(Collision2D other) {
          if(other.gameObject.CompareTag("Player"))
        {  
             if(playerHealth.health >= 0)
        {
            playerHealth.GetHurt(2);
        }
        } 
    }
}