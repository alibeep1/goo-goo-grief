using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class passenger : MonoBehaviour
{
    [SerializeField] float annoyance_ceil = 10.0f;
    [SerializeField] float curr_annoyance = 1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void increase_annoyance(float inc)
    {
        if (inc > 0)
        {
            float new_curr_annoyance = curr_annoyance + inc;
            curr_annoyance = Math.Clamp(new_curr_annoyance, 0, annoyance_ceil);
            //curr_annoyance = Mathf.Min(new_curr_annoyance, curr_annoyance);

            //curr_annoyance = 1 + curr_annoyance * percent_inc;
            //if (curr_annoyance > annoyance_ceil)
            //{
            //    curr_annoyance = annoyance_ceil;
            //}
            //curr_annoyance = percent_inc * annoyance_ceil;
        }
        Debug.Log($"New Annoyance: {curr_annoyance}");
    }
}
