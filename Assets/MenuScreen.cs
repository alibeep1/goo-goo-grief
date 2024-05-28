using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] AudioSource bgMusic = null;
    private float originalVolume;
    //private float originalPitch;

    void Start()
    {
        if (bgMusic != null)
        {
            originalVolume = bgMusic.volume;
            //originalPitch = bgMusic.pitch;
        }
    }
    public void pause()
    {
        Debug.Log(pauseMenu);
        if (bgMusic != null && !pauseMenu.activeInHierarchy)
        {
            //Debug.Log($"Init volume: {originalVolume}");
            //Debug.Log($"Init pitch: {originalPitch}");
            pauseMenu.SetActive(true);
            bgMusic.volume = originalVolume / 3;
            //bgMusic.pitch = originalPitch * 0.6f;
            //Debug.Log($"New volume: {bgMusic.volume}");


        }
        Time.timeScale = 0f;
    }
    //public void resume()
    //{
    //    pauseMenu.SetActive(false);
    //    Time.timeScale = 1f;
    //}
    //public void Home()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("StartMenu");
    //}
    //public void Restart()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("SampleScene");
    //}
    //public void Play()
    //{
    //    SceneManager.LoadScene("Menu");
    //}
}
