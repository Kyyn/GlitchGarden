using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destory on load: " + name);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        SceneManager.sceneLoaded += deleMusic;
    }

    void deleMusic (Scene scene, LoadSceneMode mode)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
        Debug.Log("Playing clip: " + thisLevelMusic);

        if (thisLevelMusic)
        { // If there's some music attached
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            //float volume = PlayerPrefsManager.GetMasterVolume();
            //audioSource.volume = volume;
            audioSource.Play();
        }
    }

    /* void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        Debug.Log("Playing clip: " + thisLevelMusic);

        if (thisLevelMusic)
        { // If there's some music attached
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    } */

    public void ChangeVolume (float volume)
    {
        audioSource.volume = volume;
    }
}
