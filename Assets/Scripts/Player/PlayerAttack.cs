using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private EnemyHealthController enemyHealth;
    private EnemyHealthController bossHealth;

    private GameObject enemyPrefab;
    private GameObject bossPrefab;
    private Vector3 initialPosition;
        // Start is called before the first frame update
    void Start()
    {
        try
        {
            enemyPrefab = GameObject.FindGameObjectWithTag("Enemy");
            enemyHealth = enemyPrefab.GetComponent<EnemyHealthController>();
            bossPrefab = GameObject.FindGameObjectWithTag("Boss");
            bossHealth = bossPrefab.GetComponent<EnemyHealthController>();
        }
        catch (System.Exception)
        {
            
            //Debug.Log("No esta el boss");
        }
        initialPosition = transform.position;
    }

    // Update is called once per frame
   void Update()
    {
        // Calcular la distancia recorrida
        float distanceTravelled = Vector3.Distance(initialPosition, transform.position);

        // Destruir el objeto si la distancia es mayor a 10
        if (distanceTravelled > 10f)
        {
            Destroy(gameObject);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemyHealth.GetHurt(10);
            Destroy(gameObject);
        }else if(other.gameObject.CompareTag("Boss"))
        {
            bossHealth.GetHurt(10);
            Destroy(gameObject);
        }else if(other.gameObject.CompareTag("Map"))
        {
            Destroy(gameObject);
        }  
    } 
}
