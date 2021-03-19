using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.Characters.FirstPerson;

public class RoundManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] enemies;
    public AudioClip[] clips;

    public static bool hasLost;
    public GameObject apear;
    public FirstPersonController fpsController;

    public GameObject lost;
    public AudioSource MusicManager;
    public Text killText;
    public Text roundText;


    Player player;

    public static int totalEnemies;

    public static int TotalEnemies
    {
        get { return totalEnemies; }
        set { totalEnemies = value; }
    }

    public PostProcessProfile profile;
    
    private static int enemyCount;


    public static int Enemies
    {
        get { return enemyCount; }
        set { enemyCount = value; }
    }


    public Text rnd;
    public static int round;

    public static int Rounds
    {
        get { return round; }
        set { round = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemyCount = 0;
        round = 1;
        hasLost = false;

    }

    // Update is called once per frame
    void Update()
    {
        rnd.text = "Round : " + round;

        if (GameObject.FindGameObjectWithTag("Enemy") == null && (enemyCount != round * 5))
        {

            for (int i = 0; i < round * 5; i++)
            {
                int spawn = Random.Range(0, 3);
                int enemy = Random.Range(0, 2);

                Instantiate(enemies[enemy], spawnPoints[spawn].transform.position, Quaternion.identity);

                GameObject effect = Instantiate(apear, spawnPoints[spawn].transform.position, Quaternion.identity) as GameObject;
                
                Destroy(effect, 0.5f);
            }

        }
        if (enemyCount == round * 5)
        {
            enemyCount = 0;
            round++;
        }

        if(round%5 == 0)
        {
            profile.GetSetting<ColorGrading>().temperature.value = -100f;
            //cambia el ambiente.

        }
        else
        {
            profile.GetSetting<ColorGrading>().temperature.value = 1f;
        }
        //se crea una cantidad especifica de enemigos.


    }

    public void Lost()
    {
        WinCave.losewin = true;
        hasLost = true;
        Time.timeScale = 0f;
        lost.SetActive(true);
        

        lost.GetComponent<AudioSource>().Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        FirstPersonController.active = false;
        player.enabled = false;

        killText.text = "Kills: " + RoundManager.TotalEnemies;
        roundText.text = "Round: " + RoundManager.Rounds;
    }

    

}
