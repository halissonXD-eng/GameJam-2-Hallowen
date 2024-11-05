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
            // Girar hacia la izquierda (180 grados en el eje Y)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontalInput < 0)
        {
            // Girar hacia la derecha (0 grados en el eje Y)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + (movementDirection * movementSpeed *  Time.deltaTime)); 
    }

    
}
