using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDamage : MonoBehaviour
{
    public bool isDamageUp;
    // Start is called before the first frame update
    void Start()
    {
      
    }


    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.CompareTag("Player"))
        {
            isDamageUp = true;
            gameObject.SetActive(false);
        }
    }
}
