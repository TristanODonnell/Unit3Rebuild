using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIHealthIndicator : MonoBehaviour
{
    [SerializeField] private HealthModule healthModule;
    [SerializeField] private TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        UpdateHealthText(healthModule.healthPoints);
    }   

    public void UpdateHealthText(int healthValue) 
    { 
        healthText.text = healthValue.ToString();
    }    
}    