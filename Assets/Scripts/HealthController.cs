using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField] public float maxHealth;
    public float health;
    private SlideLifeController slideLife;
    private GameObject slider;
    public bool gameOver;

    //Prueba
    ScoreManager score;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider = GameObject.FindGameObjectWithTag("Slider");
        slideLife = slider.GetComponent<SlideLifeController>();
        slideLife.SetSliderLife(health);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void GetHurt(int amount)
    {
        health -= amount;
        slideLife.SetActualLife(health);
        if (health <= 0){
            gameObject.SetActive(false);
            gameOver = true;
        }
    }
    

    public float GetHealth()
    {
        return health;
    }
}
