using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float autoLoadNextLevelAfter;

    private void Start()
    {
        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Autolevel disabled");
        } else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
            Debug.Log("Autolevel Enable");
        }

    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested:" + name);
        SceneManager.LoadScene(name);

    }
    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}