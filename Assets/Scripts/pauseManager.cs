 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour
{


    public FirstPersonController fpsController;
    Player player;

    public GameObject pauseMenu;
    public GameObject configMenu;
    public GameObject LevelLoader;
    // Start is called before the first frame update
    void Start()
    {
       
        FirstPersonController.Enabled = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        pauseMenu.SetActive(false);

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            TogglePause();
        }
    }

    public void ToggleConfig()
    {
        if (configMenu)
        {
            configMenu.SetActive(!configMenu.activeSelf);
        }
    }

    public void TogglePause()
    {
        if (pauseMenu)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            
            FirstPersonController.active = !FirstPersonController.active;

            
            if (pauseMenu.activeSelf)
            {
                player.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                player.enabled = true;
            }

            Time.timeScale = pauseMenu.activeSelf ? 0.0f : 1.0f;
        }

    }

    public void restartGame()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(SceneLoad(SceneManager.GetActiveScene().buildIndex));
    }

    public void mainMenu()
    {
        Time.timeScale = 1.0f;
        
        StartCoroutine(SceneLoad(0));
    }

    public void resume()
    {
        TogglePause();
    }

    private IEnumerator SceneLoad(int scene)
    {
        LevelLoader.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        while (!operation.isDone)
            yield return null;

    }


}
