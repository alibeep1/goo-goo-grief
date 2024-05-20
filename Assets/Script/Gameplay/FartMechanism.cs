using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartMechanism : MonoBehaviour
{
    public ParticleSystem particlesystem;
    [SerializeField] InputActionManager inputActions = null;
    [SerializeField] bool fartEnable = false;
    [SerializeField] ProgressBar prog;
    [SerializeField] float annoyance_inc = 0.01f;

    private void Start()
    {
        // If particlesystem reference is not assigned, try to get it from the GameObject
        if (particlesystem == null)
        {
            particlesystem = GetComponent<ParticleSystem>();
        }

        if (inputActions != null)
        {
            inputActions.RegisterToButtonEvents(Button_listener);
        }
    }


    void Button_listener(IInputAction<bool> i_value, KeyCode i_keyCode)
    {
        if (i_keyCode == KeyCode.F)
        {
            Fart_handler();
        }
    }
    void Fart_handler()
    {
        Vector2 particlesystemposition = transform.position + Vector3.up * 1.4f;
        particlesystemposition.y = particlesystemposition.y - 2.5f;

        Vector3 rotation = transform.rotation.eulerAngles;
        //Debug.Log(rotation.z);
        if (rotation.z == 90)
        {
            particlesystem.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (rotation.z == 270)
        {
            particlesystem.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (rotation.z == 180)
        {
            particlesystem.transform.rotation = Quaternion.Euler(270, 0, 0);
        }
        else
        {
            particlesystem.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        // particlesystem.transform.rotation.x = transform.rotation;
        particlesystem.transform.position = particlesystemposition;
        var em = particlesystem.emission;
        var dur = particlesystem.duration;
        em.enabled = true;
        //prog.IncProgressBar(0.05f);
        Debug.Log($"Farted at {DateTime.Now}");
        particlesystem.Play();
        StartCoroutine(BabyFartDuration(1.0f));
    }

    private void OnParticleCollision(GameObject particle)
    {
        //var collidedObject = particle.gameObject;
        Debug.Log($"Fart -> Collided with Object");
    }

    IEnumerator BabyFartDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        var em = particlesystem.emission;
        em.enabled = false;
    }

}


// public bool once = true;
// private void OnTriggerEnter2D (Collider2D other) {
// if (other.gameObject.CompareTag ("Player") && once) {
// var em = collisionParticleSystem.emission;
// var dur = collisionParticlesystem duration;
// em.enabled = true;
// collisionParticleSystem. Play () ;
// once = false;
// Destroy (sr);
// Invoke (nameof (DestroyObj), dur);