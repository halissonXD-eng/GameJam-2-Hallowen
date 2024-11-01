using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public GameObject BatPrefab;
    public float batSpeed = 10f;
    public float batInterval = 0.1f;
    public int batCount = 1;

    private bool isShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;
            Vector3 direction = (targetPosition - transform.position).normalized;

            StartCoroutine(ShootBat(direction));
        }
    }
    private IEnumerator ShootBat(Vector3 direction)
    {
        isShooting=true;

        for (int i = 0; i < batCount; i++)
        {
            GameObject bat = Instantiate(BatPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bat.GetComponent<Rigidbody2D>();
            rb.velocity = direction * batSpeed;

            yield return new WaitForSeconds(batInterval);
        }

        isShooting = false;
    }
}
