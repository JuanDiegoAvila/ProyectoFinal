using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCollide : MonoBehaviour
{
    AudioSource agarrar;

    private void Start()
    {
        agarrar = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            agarrar.Play();
            if(StaffAttack.cave == false)
                other.gameObject.GetComponent<Player>().health += 5;
            if(StaffAttack.cave == true)
                other.gameObject.GetComponent<PlayerCave>().health += 5;
            Destroy(gameObject, 0.7f);
            
            
            
        }

    }
}
