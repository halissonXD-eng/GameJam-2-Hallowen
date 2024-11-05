using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
   
    [SerializeField] public float maxHealth;
    public float health;
    
    private ScoreManager score;
    private GameObject scorePrefab;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void GetHurt(int amount)
    {
        scorePrefab = GameObject.Find("GameManager");
        score = scorePrefab.GetComponent<ScoreManager>();
        health -= amount;
        animator.SetTrigger("Herido");
        if (health <= 0)
        {
            if(gameObject.CompareTag("Enemy"))
            {
                score.AddScore(25);
                StartCoroutine(DieAnimation()); 
                
            } else if(gameObject.CompareTag("Boss"))
            {
                score.AddScore(50);
                StartCoroutine(DieAnimation()); 
            }
        }
    }

    IEnumerator DieAnimation()
    {
        animator.SetBool("Muerto",true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        gameObject.SetActive(false);
        health = maxHealth;
    }
}
