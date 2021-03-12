using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    Slider healthSlider;

    public float maxHealth;
    public float health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider = GetComponentInChildren<Slider>();
        healthSlider.value = CalculateHealth();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = CalculateHealth();
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
