using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameTimer : MonoBehaviour {

    public float levelSeconds = 100;

    private Slider slider;
    private LevelManager levelManager;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private GameObject winLabel;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();

        winLabel = GameObject.Find("Win");
        if (!winLabel)
        {
            Debug.Log("No WinLabel found");
        }
        winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        slider.value = 1 - Time.timeSinceLevelLoad / levelSeconds;



        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            DestroyAllTaggedObjects();
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndOfLevel = true;
        }

	}
    void DestroyAllTaggedObjects()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");

        foreach (GameObject taggedobj in gameObjectArray)
        {
            Destroy(taggedobj);
        }

    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
