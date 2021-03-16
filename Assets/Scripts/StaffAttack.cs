using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffAttack : MonoBehaviour
{
    private bool canAttack;
  
    private void OnCollisionEnter(Collision collision)
    {
        if((gameObject.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) % 1 <= 0.5f)
            canAttack = true;
        else
            canAttack = false;
        

        if (collision.gameObject.tag == "Player" && canAttack)
        {
            collision.gameObject.GetComponent<Player>().health -= 1.0f;
        }

    }
}
