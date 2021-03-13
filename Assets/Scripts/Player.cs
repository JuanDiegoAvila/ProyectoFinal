using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static float health;

    public Text healthText;
    public Slider healthSlider;

    public AudioSource shot;

    public ParticleSystem bullet;

    public static float Health
    {
        get { return health; }
        set { health = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
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
                }
            }
            
        }
        
    }

   
}
