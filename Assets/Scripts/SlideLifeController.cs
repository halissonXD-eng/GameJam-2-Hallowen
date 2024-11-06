using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideLifeController : MonoBehaviour
{
    [SerializeField] private Slider slider;
  
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLifeMax(float maxLife)
    {
        slider.maxValue = maxLife;
    }
    
    public void SetActualLife(float amountLife)
    {
        slider.value = amountLife;
    }
    
    public void SetSliderLife(float valueLife)
    {
        SetLifeMax(valueLife);
        SetActualLife(valueLife);
    }

    
}
