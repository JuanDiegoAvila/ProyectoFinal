using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    public GameObject spawnpoint;
    public GameObject boss;
    bool activated;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (activated == false)
        {
                Instantiate(boss, spawnpoint.transform.position, Quaternion.identity);
        }
        activated = true;
    }
}
