using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health;

    public Text healthText;
    public Slider healthSlider;

    public GameObject rnd;
    RoundManager rManager;

    public AudioSource shot;
    public GameObject musicManager;
    AudioSource backMusic;
    public ParticleSystem bullet;


    // Start is called before the first frame update
    void Start()
    {
        backMusic = musicManager.GetComponent<AudioSource>();
        rManager = rnd.GetComponent<RoundManager>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health/100;
        healthText.text = health+"";

        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Input.GetMouseButtonDown(0))
        {
            shot.Play();
            bullet.Play();

            if(Physics.Raycast(myRay, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    hitInfo.collider.GetComponentInParent<Enemy>().health -= 20f;
                    hitInfo.collider.GetComponentInParent<Enemy>().GetComponent<Animator>().SetBool("GetHit", true);
                }
            }
            
        }

        if (health <= 0)
        {
            rManager.Lost();

            backMusic.Stop();
        }

        if(health > 100)
        {
            health = 100;
        }


    }

   
}
