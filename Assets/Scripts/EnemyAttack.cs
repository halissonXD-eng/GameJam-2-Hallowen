using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    private HealthController playerHealth;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
   

    private void OnCollisionEnter2D(Collision2D other) {
          if(other.gameObject.CompareTag("Player") && playerHealth.health >= 0)
        {  
            animator.SetTrigger("atacando");
            int damage = gameObject.CompareTag("Boss") ? 4 : 2;
            playerHealth.GetHurt(damage);
        
        } 
    }

}