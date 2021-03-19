using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class WinCave : MonoBehaviour
{
    public GameObject Win;
    bool activated;

    public static bool losewin;
    public FirstPersonController fpsController;
    public AudioClip[] sounds;
    public Text texto;

    public AudioSource musicManager;
    public GameObject winAudioSource;
    AudioSource state;

    PlayerCave player;
    // Start is called before the first frame update
    void Start()
    {
        losewin = false;
        state = winAudioSource.GetComponent<AudioSource>();
        Win.SetActive(false);
        activated = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCave>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0)
        {
            Lose();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    
        losewin = true;
        RoundManager.hasLost = true;
        state.clip = sounds[1];
        state.Play();

        texto.text = "You Win";
        Time.timeScale = 0.0f;
        Win.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        FirstPersonController.active = false;
        player.enabled = false;


    }

    private void Lose()
    {
        if (player.health <= 0)
        {
            losewin = true;
            RoundManager.hasLost = true;
            musicManager.Stop();

            state.clip = sounds[0];
            state.Play();

            texto.text = "You Lost";
            Time.timeScale = 0.0f;
            Win.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            FirstPersonController.active = false;
            player.enabled = false;
        }
        else
        {
            losewin = false;
            RoundManager.hasLost = false;
        }
    }

}