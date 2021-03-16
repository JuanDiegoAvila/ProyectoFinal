using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject LevelLoader;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void fps()
    {
        
        StartCoroutine(SceneLoad(1)); 
    }

    public void Cave()
    {
        StartCoroutine(SceneLoad(2)); 
    }

    public void exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private IEnumerator SceneLoad(int scene)
    {
        LevelLoader.SetActive(!LevelLoader.activeSelf);
        yield return SceneManager.LoadSceneAsync(scene);
        LevelLoader.SetActive(!LevelLoader.activeSelf);
    }
}
