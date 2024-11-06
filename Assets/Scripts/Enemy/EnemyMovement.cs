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
   private bool isFacingRight = true;

   private EnemyHealthController healthEnemy;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        healthEnemy = GetComponent<EnemyHealthController>();
    }

    void Update()
    {
       
    }
    void FixedUpdate()
    {
        Follow();
        LookAtPlayer();
    }

    private void Follow()
    {
        //Mientas sea mayor a la minima distancia se mueve, sino ataca
        if(!isOnTouchPlayer && !healthEnemy.isDead)
        {
            animator.SetBool("caminando",true);
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
            animator.SetBool("caminando",false);
        } 
        
    }

    private void Flip()
    {
        // Invertir la escala en el eje X para mirar en la dirección correcta
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1; // Invertir el eje X
        transform.localScale = newScale;
    }

     private void LookAtPlayer()
    {
        // Determinar la dirección del jugador respecto al enemigo
        if (player.position.x > transform.position.x)
        {
            // El jugador está a la derecha
            if (!isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            // El jugador está a la izquierda
            if (isFacingRight)
            {
                Flip();
            }
        }
    }
}
