using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class passenger : MonoBehaviour
{
    [SerializeField] float annoyance_ceil = 10.0f;
    [SerializeField] float curr_annoyance = 1f;
    [SerializeField] float fart_inc= 0.01f;
    [SerializeField] ProgressBar prog;


    void Start()
    {
        GameObject progressBarObject = GameObject.FindGameObjectWithTag("progress_bar");
        if (progressBarObject != null)
        {
            prog = progressBarObject.GetComponent<ProgressBar>();
        }
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
            prog.IncProgressBar(inc);

            curr_annoyance = Math.Clamp(new_curr_annoyance, 0, annoyance_ceil);
            Debug.Log($"New Annoyance: {curr_annoyance}");
        }
    }

    private void OnParticleCollision(GameObject particle)
    {
        //var collidedObject = particle.gameObject;
        increase_annoyance(fart_inc);
        prog.IncProgressBar(fart_inc);
        Debug.Log($"passenger -> Collided with fart object");
    }


    // Is called when the baby collides with the circular collider of a passenger
    // Handle showing the passenger meter / exclamation mark here
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"TRIGGERED ");
        var collidedObject = collision.gameObject;
        //var collider = collision.collider;

        //Debug.Log($"PASSENGER collided with {collidedObject.name}");
        //Debug.Log($"collidedObject.tag: {collidedObject.tag}, collision: {collision.name}");
        if (collidedObject.tag == "Player")
        {
            Debug.Log("PASSENGER CIRCLE COLLIDER with baby's CIRCLE collider...");
            //return;
        }
    }
}
