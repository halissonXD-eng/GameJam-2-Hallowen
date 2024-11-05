using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints; 
    private int enemiesPerRound = 2;

    public bool bossAvailable;

    RoundManager round;

    void Start()
    {
        round = GameObject.Find("DataManager").GetComponent<RoundManager>();

       StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
              if(round.round % 5 == 0)
            {
                bossAvailable = true;
            }else
            {
                bossAvailable = false;
            }

           

            
            for(int i = 0; i < enemiesPerRound; i++)
            {
                int enemyPosIndex = Random.Range(0,spawnPoints.Length);
                GameObject enemy = EnemyPool.Instance.RequestEnemy();
                enemy.transform.position = spawnPoints[enemyPosIndex].transform.position;

                if(bossAvailable)
                {
                    int bossPosIndex = Random.Range(0,spawnPoints.Length);
                    GameObject boss = EnemyPool.Instance.RequestBoss();
                    boss.transform.position = spawnPoints[bossPosIndex].transform.position;
                    bossAvailable = false;
                }

                yield return new WaitForSeconds(2);
            }
            

            // Espera hasta que todos los enemigos estén desactivados
            yield return new WaitUntil(EnemyInactive);

            round.UpdateRound();
            // Espera 5 segundos antes de iniciar la próxima ronda
            yield return new WaitForSeconds(5f);
            
            
            // Incrementa la cantidad de enemigos para la próxima ronda
            enemiesPerRound += 2;

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
