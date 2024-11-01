using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed, minDistance;
    [SerializeField] private float knockBackPower;
     public bool isOnTouchPlayer;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        //Mientas sea mayor a la minima distancia se mueve, sino ataca
        if(!isOnTouchPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        if(Vector2.Distance(transform.position, player.transform.position) > minDistance)
        {
            isOnTouchPlayer = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
          if(other.gameObject.CompareTag("Player"))
        {  
            Vector2 pushDirection = (other.transform.position - transform.position).normalized;
            other.rigidbody.AddForce(pushDirection * knockBackPower, ForceMode2D.Impulse);
            isOnTouchPlayer = true;
        } 
        
    }
  
}
