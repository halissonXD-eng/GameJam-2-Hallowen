using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
   
    [SerializeField] public float maxHealth;
    public float health;
    
    private ScoreGame score;
    private Animator animator;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        isDead = false;
    }


    public void GetHurt(int amount)
    {

        score = GameObject.Find("UI").GetComponent<ScoreGame>();
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
