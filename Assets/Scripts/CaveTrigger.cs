using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveTrigger : MonoBehaviour
{
    public GameObject spawnpoint;
    public GameObject lich;
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
        if(activated == false)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(lich, spawnpoint.transform.position, Quaternion.identity);
            }
        }
        activated = true;
    }
}
