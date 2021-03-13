using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] enemies;
    public AudioClip[] clips;

    private static int enemyCount;

    public static int Enemies
    {
        get { return enemyCount; }
        set { enemyCount = value; }
    }
    public Text rnd;
    public int round;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
        round = 1;

    }

    // Update is called once per frame
    void Update()
    {
        rnd.text = "Round : "+round;
        
        if (GameObject.FindGameObjectWithTag("Enemy") == null && (enemyCount != round*5))
        {

            for (int i = 0; i < round * 5; i++)
            {
                int spawn = Random.Range(0, 3);
                int enemy = Random.Range(0, 2);
                Instantiate(enemies[enemy], spawnPoints[spawn].transform.position, Quaternion.identity);
            }
            
        }
        if(enemyCount == round*5)
        {
            enemyCount = 0;
            round++;
        }
        
        //se crea una cantidad especifica de enemigos.
       

    }
}
