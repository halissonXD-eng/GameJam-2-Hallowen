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
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        isDead = false;
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
                isDead = true;
                score.AddScore(25);
                StartCoroutine(DieAnimation()); 
                
            } else if(gameObject.CompareTag("Boss"))
            {
                score.AddScore(50);
                isDead = true;
                StartCoroutine(DieAnimation()); 
            }
        }
    }

    IEnumerator DieAnimation()
    {
        animator.SetBool("Muerto",true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        gameObject.SetActive(false);
        isDead = false;
        health = maxHealth;
    }
}
