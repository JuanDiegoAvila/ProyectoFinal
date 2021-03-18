using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    Slider healthSlider;
    Animator an;

    public bool beingKilled = false;
    public bool destroy = false;
    public float maxHealth;
    public float health;

    public AudioSource Killed;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        Killed = GameObject.FindGameObjectWithTag("Enemy Killed").GetComponent<AudioSource>();
        an = GetComponent<Animator>();
        health = maxHealth;
        healthSlider = GetComponentInChildren<Slider>();
        healthSlider.value = CalculateHealth();

        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        an.SetFloat("Life", health);
        an.SetBool("InRange", false);

        if (agent)
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);

        an.SetFloat("Speed", agent.speed);

        if(agent.remainingDistance <= 10f)
        {
            agent.isStopped = true;
            an.SetBool("InRange", true);
        }
        else
        {
            agent.isStopped = false;
            an.SetBool("InRange", false);
        }

        healthSlider.value = CalculateHealth();
        if(health <= 0)
        {
            
            agent.isStopped = true;
            StartCoroutine("killed");
            
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

    IEnumerator killed()
    {
        
        yield return new WaitForSeconds(3);
      
        Destroy(gameObject);

        RoundManager.Enemies += 1;
        RoundManager.totalEnemies += 1;
        Killed.Play();
        
    }

}
