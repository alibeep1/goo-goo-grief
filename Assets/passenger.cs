using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class passenger : MonoBehaviour
{
    [SerializeField] float annoyance_ceil = 10.0f;
    [SerializeField] float curr_annoyance = 1f;
    [SerializeField] float fart_inc = 0.01f;
    [SerializeField] ProgressBar prog;
    [SerializeField] GameObject exclamationMark = null;

    private bool alreadyBothered = false;
    void Start()
    {
        GameObject progressBarObject = GameObject.FindGameObjectWithTag("progress_bar");
        if (progressBarObject != null)
        {
            prog = progressBarObject.GetComponent<ProgressBar>();
        }
        else
        {
            Debug.Log("Passenger: Couldnt find a progressbar");
        }
    }

    private void Update()
    {
        if (exclamationMark != null)
        {

            if (alreadyBothered && exclamationMark.GetComponent<SpriteRenderer>().enabled == false)
            {

                Debug.Log("ALREADY BOTHERED...");
                exclamationMark.GetComponent<SpriteRenderer>().enabled = true;
                Debug.Log($"Exclamation Mark Obj: {exclamationMark.GetComponent<SpriteRenderer>().enabled}");

            }
        }
        else
        {
            Debug.Log($"NULL: exclamationMark, {exclamationMark}");
        }
    }

    public void increase_annoyance(float inc)
    {


        if (inc > 0 && !alreadyBothered)
        {
            //Debug.Log($"Inc Annoyance, inc: {inc}, ");
            float new_curr_annoyance = curr_annoyance + inc;
            prog.IncProgressBar(inc);

            curr_annoyance = Math.Clamp(new_curr_annoyance, 0, annoyance_ceil);

            alreadyBothered = true;
            //Debug.Log($"New Annoyance: {curr_annoyance}");
        }
    }

    private void OnParticleCollision(GameObject particle)
    {
        //var collidedObject = particle.gameObject;
        //Debug.Log($"passenger -> Collided with fart object");
        if (!alreadyBothered)
        {
            increase_annoyance(fart_inc);
            prog.IncProgressBar(fart_inc);
            alreadyBothered = true;
        }
    }


    // Is called when the baby collides with the circular collider of a passenger
    // Handle showing the passenger meter / exclamation mark here
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"TRIGGERED ");
        var collidedObject = collision.gameObject;

        //Debug.Log($"PASSENGER collided with {collidedObject.name}");
        //Debug.Log($"collidedObject.tag: {collidedObject.tag}, collision: {collision.name}");
        if (collidedObject.tag == "Player")
        {
            Debug.Log("PASSENGER CIRCLE COLLIDER with baby's CIRCLE collider...");
            //exclamationMark.GetComponent<SpriteRenderer>().enabled = true;

            //return;
        }

    }

    // Is called when the baby leaves the circular collider of a passenger
    // Handle hiding the passenger meter / exclamation mark here
    private void OnTriggerExit2D(Collider2D collision)
    {
        var collidedObject = collision.gameObject;
        if (collidedObject.tag == "Player")
        {
            Debug.Log("PASSENGER CIRCLE COLLIDER exited by baby's CIRCLE collider...");
            // Hide the exclamation mark when the player leaves the trigger area
            exclamationMark.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
