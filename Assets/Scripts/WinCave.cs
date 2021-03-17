using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class WinCave : MonoBehaviour
{
    public GameObject Win;
    bool activated;
    public FirstPersonController fpsController;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        Win.SetActive(false);
        activated = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (activated == false)
        {
            Time.timeScale = 0.0f;
            Win.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            FirstPersonController.active = false;
            player.enabled = false;
        }
        activated = true;

    }

}