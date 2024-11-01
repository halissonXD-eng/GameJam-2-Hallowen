using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private int poolSize;

     //Creamos el patron Singleton para obtener los metodos y variables del script sin referenciarlo en otros
    private static EnemyPool instace;
    public static EnemyPool Instance { get {return instace;}}

    private void Awake() {
        if(instace == null)
        {
            instace = this;
        }else 
        {
            Destroy(gameObject);
        }
    }
    //Singleton Creado


        // Start is called before the first frame update
    void Start()
    {
        AddEnemyToPool(poolSize);
    }

    // Añadimos los enemigos segun el sistema de diseño Object Pooling
    private void AddEnemyToPool(int amount)
    {
        //Se crea un for para instanciar cada prefab en la lista y lo ponga como desactivado
        for(int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyList.Add(enemy);
            enemy.transform.parent = transform;
        }
    }

    // Activa el enemigo cuando sea necesario
    public GameObject RequestEnemy()
    {
          for(int i = 0; i < enemyList.Count; i++)
        {
            if(!enemyList[i].activeSelf)
            {
                enemyList[i].SetActive(true);
                return enemyList[i];
            }
        }
        // Hace la lista dinamica en caso de que se requieran mas prefabs
        AddEnemyToPool(1);
        enemyList[enemyList.Count - 1].SetActive(true);
        return enemyList[enemyList.Count - 1];
    }
}
