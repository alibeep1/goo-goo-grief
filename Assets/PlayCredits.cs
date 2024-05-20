using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCredits : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Credits");
    }
}
