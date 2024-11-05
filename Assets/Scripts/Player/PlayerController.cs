using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector2 movementDirection;
    [SerializeField] Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        movementDirection = new Vector2(horizontalInput, Input.GetAxisRaw("Vertical")).normalized;
         // Rotar el jugador según la dirección de movimiento horizontal
         if (horizontalInput > 0)
        {
            // Girar hacia la izquierda (resta la scala en x)
            transform.localScale = new Vector3(-2.5f,2.5f,2.5f);
        }
        else if (horizontalInput < 0)
        {
            // Girar hacia la derecha
            transform.localScale = new Vector3(2.5f,2.5f,2.5f);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + (movementDirection * movementSpeed *  Time.deltaTime)); 
    }

    
}
