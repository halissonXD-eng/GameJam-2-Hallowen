using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    public float maxHealth;
    public float health;
    private SlideLifeController slideLife;
    [SerializeField] private GameObject slider;
    public bool gameOver;
    private Animator animator;

    // Event
    public event EventHandler playerDeath;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        //slider = GameObject.FindGameObjectWithTag("Slider");
        slideLife = slider.GetComponent<SlideLifeController>();
        animator = GetComponent<Animator>();
        slideLife.SetSliderLife(health);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void GetHurt(int amount)
    {
        health -= amount;
        animator.SetTrigger("Herido");
        slideLife.SetActualLife(health);
        if (health <= 0)
        {
            StartCoroutine(DieAnimation()); 
            playerDeath?.Invoke(this, EventArgs.Empty);
        }
    }
    

    public float GetHealth()
    {
        return health;
    }

    IEnumerator DieAnimation()
    {
        animator.SetBool("Muerto",true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        gameOver = true;
        gameObject.SetActive(false);
    }
}
