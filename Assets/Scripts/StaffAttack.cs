using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffAttack : MonoBehaviour
{
    private bool canAttack;
    public static bool cave = false;
    AudioSource Hit;

    private void Start()
    {
        Hit= GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((gameObject.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) % 1 <= 0.5f)
            canAttack = true;
        else
            canAttack = false;
        

        if (collision.gameObject.tag == "Player" && canAttack)
        {
            if (!Hit.isPlaying)
            {
                Hit.Play();
            }
            if (cave)
            {
                collision.gameObject.GetComponent<PlayerCave>().health -= 1.0f;
            }
            else
            {
                collision.gameObject.GetComponent<Player>().health -= 1.0f;
            }
            
        }

    }
}
