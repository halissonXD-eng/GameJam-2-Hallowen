using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints; 
    private int enemiesPerRound = 2;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for(int i = 0; i < enemiesPerRound; i++)
            {
                int enemyPosIndex = Random.Range(0,spawnPoints.Length);
                GameObject enemy = EnemyPool.Instance.RequestEnemy();
                enemy.transform.position = spawnPoints[enemyPosIndex].transform.position;

                yield return new WaitForSeconds(2);
            }
            
            // Espera hasta que todos los enemigos estén desactivados
            yield return new WaitUntil(EnemyInactive);

            // Espera 5 segundos antes de iniciar la próxima ronda
            yield return new WaitForSeconds(5f);

            // Incrementa la cantidad de enemigos para la próxima ronda
            enemiesPerRound += 2;
            Debug.Log("Nueva ronda: " + enemiesPerRound);

        }
    }

    private bool EnemyInactive()
    {
        int enemiesStatus = FindObjectsOfType<EnemyMovement>().Length;
        if(enemiesStatus != 0)
        {
            return false;
        }

        return true;
    }
}
