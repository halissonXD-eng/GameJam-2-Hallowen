using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private EnemyHealthController bossHealth;

    [SerializeField] private GameObject powerUpPrefab;
    private GameObject powerUpInstance; // Instancia del PowerUp
    void Start()
    {
        bossHealth = GetComponent<EnemyHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica si el boss ha muerto y si el powerUp aún no ha sido instanciado
        if (bossHealth.isDead && powerUpInstance == null)
        {
            ActivePowerUp();  // Llama a la función que crea el powerUp
            Debug.Log("Se creo el powerup");
        }
    }

    public void ActivePowerUp()
    {
        // Solo crea el powerUp si no ha sido instanciado previamente
        if (powerUpInstance == null)
        {
            // Instanciamos el PowerUp en la posición del Boss
            powerUpInstance = Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            StartCoroutine(DestroyPowerUpAfterTime(7f));  // Destruir después de 7 segundos
        }
    }

    IEnumerator DestroyPowerUpAfterTime(float time)
    {
        // Espera 7 segundos y luego desactiva el powerUp
        yield return new WaitForSeconds(time);
        if (powerUpInstance != null)
        {
            Destroy(powerUpInstance);  // Destruye el PowerUp
        }
    }
}
