using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float fillSpeed = 0.001f;
    [SerializeField] private float progress = 0f;
    [SerializeField] GameOverScript gameOver = null;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();

    }

    void Update()
    {
        if (slider.value < progress)
        {
            slider.value = slider.value + fillSpeed;
            Debug.Log($"Slider Val: {slider.value}");
            Debug.Log($"Progress: {progress}");
        }
        if(slider.value >= 1f)
        {
            gameOver.GameWon();
        }
        //if (progress >= 10f)
        //{
        //    gameOver.GameWon();
        //}
        //else
        //{
        //    Debug.Log($"Progress: {progress}");

        //}
    }

    public void IncProgressBar(float Value)
    {
        progress = slider.value + Value;
        Debug.Log($"New Progress bar: {progress}");
    }
}
