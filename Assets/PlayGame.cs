
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] AudioSource bgMusic = null;
    [SerializeField] GameObject helpMenu = null;

    private float originalVolume;
    //private float originalPitch;

    void Start()
    {
        if (bgMusic != null)
        {
            originalVolume = bgMusic.volume;
            Debug.Log($"Start -> OriginalVolume: {originalVolume}");
            //originalPitch = bgMusic.pitch;
        }
    }
    public void ExitApp()
    {
        Debug.Log("Credits Handler called");
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void pause()
    {
        Debug.Log(pauseMenu);
        if (bgMusic != null && !pauseMenu.activeInHierarchy)
        {
            //Debug.Log($"Init volume: {originalVolume}");
            //Debug.Log($"Init pitch: {originalPitch}");
            bgMusic.volume = originalVolume / 3;
            pauseMenu.SetActive(true);
            //bgMusic.pitch = originalPitch * 0.6f;
            //Debug.Log($"New volume: {bgMusic.volume}");


        }
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Debug.Log($"Resume -> orig volume: {originalVolume}");
        //Debug.Log($"Init pitch: {originalPitch}");
        RestoreBGMusic();
        Debug.Log($"Resume -> New volume: {bgMusic.volume}");
        //Debug.Log($"Init pitch: {originalPitch}");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void RestoreBGMusic()
    {
        if (bgMusic != null)
        {
            bgMusic.volume *= 3;
            //bgMusic.pitch = originalPitch;
        }
    }

    public void Restart()
    {
        Debug.Log("Restart clicked");
        // clear the bgMusic var here; ensuring it is reset before reload
        if (bgMusic != null)
        {
            bgMusic.Stop();
            bgMusic = null;
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void StartMenu()
    {
        Debug.Log("Start Menu clicked");
        //RestoreBGMusic();
        if (bgMusic != null)
        {
            bgMusic.Stop();
            bgMusic = null;
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
    public void Settings()
    {
        if (helpMenu != null)
        {
            helpMenu.SetActive(true);
        }

    }
    public void HideSettings()
    {
        if (helpMenu != null)
        {
            helpMenu.SetActive(false);
        }
    }
}
