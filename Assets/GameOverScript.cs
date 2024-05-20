using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] GameTimer timer;

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
        SceneManager.LoadScene("LoseMenu");
    }
}
