using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] GameTimer timer;
    [SerializeField] Attendant attendant;

    private void Start()
    {
        timer.OnTimerUpdate += CheckTimeEnded;
    }

    void CheckTimeEnded(float timeLeft)
    {
        if(timeLeft < 1)
        {
            Gameover();
        }
    }
    public void Gameover()
    {
        Debug.Log("GAMEOVERRRRR");
        SceneManager.LoadScene("LoseMenu");
    }
    public void GameWon()
    {
        Debug.Log("YOU WON");
        SceneManager.LoadScene("WinMenu");
    }
}
