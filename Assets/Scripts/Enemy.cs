using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    Slider healthSlider;

    public float maxHealth;
    public float health;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider = GetComponentInChildren<Slider>();
        healthSlider.value = CalculateHealth();

        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (agent)
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);

        healthSlider.value = CalculateHealth();
        if(health <= 0)
        {
            Destroy(gameObject);
            RoundManager.Enemies += 1;
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
