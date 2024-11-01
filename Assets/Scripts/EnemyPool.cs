using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefab;
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private int poolSize;

    private GameObject bossObject;
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
        AddBossToPool();
    }

    // Añadimos los enemigos segun el sistema de diseño Object Pooling
    private void AddEnemyToPool(int amount)
    {
        
        //Se crea un for para instanciar cada prefab en la lista y lo ponga como desactivado
        for(int i = 0; i < amount; i++)
        {
            int enemyIndex = Random.Range(0,enemyPrefab.Count);
            GameObject enemy = Instantiate(enemyPrefab[enemyIndex],transform);
            enemy.SetActive(false);
            enemyList.Add(enemy);
        }

        
    }

    private void AddBossToPool()
    {
        // Agrega el jefe como el último en la lista si aún no está
        bossObject = Instantiate(bossPrefab,transform);
        bossObject.SetActive(false);
        bossObject.transform.parent = transform;
    }

    // Activa el enemigo cuando sea necesario
    public GameObject RequestEnemy()
    {
         // Crea una lista temporal de enemigos desactivados que son hijos del EnemyPool
        List<GameObject> inactiveEnemies = new List<GameObject>();
    
        for (int i = 0; i < enemyList.Count; i++){
            if (!enemyList[i].activeSelf)
            {
                inactiveEnemies.Add(enemyList[i]);
            }
        }

        // Si hay enemigos inactivos, selecciona uno aleatorio
        if (inactiveEnemies.Count > 0)
        {
            int randomIndex = Random.Range(0, inactiveEnemies.Count);
            GameObject randomEnemy = inactiveEnemies[randomIndex];
            randomEnemy.SetActive(true);
            return randomEnemy;
        }

        // Hace la lista dinamica en caso de que se requieran mas prefabs
        AddEnemyToPool(1);
        enemyList[^1].SetActive(true);
        return enemyList[^1];
    }

    public GameObject RequestBoss()
    {   
        if (!bossObject.activeSelf)
        {
            bossObject.SetActive(true);
        }
        return bossObject;
    }

}
