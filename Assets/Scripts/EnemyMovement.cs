using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed, minDistance;
    [SerializeField] private float knockBackPower;
     public bool isOnTouchPlayer;
    private Transform player;
   private Animator animator;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       
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
            animator.SetBool("caminando",true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        if(Vector2.Distance(transform.position, player.transform.position) > minDistance)
        {
            animator.SetBool("caminando",false);
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
