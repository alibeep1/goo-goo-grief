using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomMeter : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float fillSpeed = 0.0001f;

    // Define a delegate type for broadcasting the fill percentage
    public delegate void FillPercentageDelegate(float fillPercentage);
    // Create an event of the delegate type
    public static event FillPercentageDelegate OnFillPercentageChanged;


    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < 1f)
        {
            slider.value = slider.value + fillSpeed;

            // Broadcast the fill percentage when it changes
            OnFillPercentageChanged?.Invoke(slider.value);
        }
        else
        {
            slider.value = 0f;

            // Broadcast the fill percentage when it changes
            OnFillPercentageChanged?.Invoke(slider.value);
        }
    }
}

