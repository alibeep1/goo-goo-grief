using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomMeter : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float fillSpeed = 0.0001f;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (slider.value < 1f){
            slider.value = slider.value + fillSpeed;
        }
        else {
            slider.value = 0f;
        }
    }
}

