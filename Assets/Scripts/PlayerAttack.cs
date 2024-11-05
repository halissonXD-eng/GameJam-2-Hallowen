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
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }   
}
