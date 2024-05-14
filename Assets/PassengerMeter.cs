using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassengerMeter : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float fillSpeed = 0.001f;
    [SerializeField] private float progress = 0f;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value < progress)
        {
            slider.value = slider.value + fillSpeed;
        }
    }

    public void IncProgressBar(float Value)
    {
        progress = slider.value + Value;
        //Debug.Log("PassengerMeter -> IncProgressBar CALLED\n new prog ", progress);
    }
}

