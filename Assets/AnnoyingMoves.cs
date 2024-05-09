using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnnoyingMoves : MonoBehaviour
{

    public ParticleSystem particlesystem;
    public SpriteRenderer sr;
    [SerializeField] InputActionManager inputActions = null;
    [SerializeField] float pee_distance = 20f;

    [SerializeField] GameObject missilePrefab = null;
    [SerializeField] float missileSpeed = 0.7f;
    [SerializeField] bool fartEnable = false;
    [SerializeField] ProgressBar prog;


    // Start is called before the first frame update
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
        if (i_keyCode == KeyCode.P)
        {
            Pee_handler();
        }
        
        if (i_keyCode == KeyCode.F)
        {
            Fart_handler();
            //Debug.Log("Byeee");
        }
    }

    void Pee_handler()
    {
        Vector2 rayOrigin = transform.position + Vector3.up * 1.4f;
        Debug.Log($"rayOrigin: {rayOrigin}");


        // Instantiate the Pee prefab
        GameObject missileObject = Instantiate(missilePrefab, transform.position, Quaternion.identity);

        Rigidbody2D missile = missileObject.GetComponent<Rigidbody2D>();

        Vector2 direction = transform.up.normalized;

        if (missile != null)
        {
            // Launch the Pee object as a missile in the direction of the baby's rotation and the given speed
            missile.AddForce(direction * missileSpeed, ForceMode2D.Impulse);
        }
        //prog.IncProgressBar(0.05f);

    }

    void Fart_handler()
    {
        Vector2 particlesystemposition = transform.position + Vector3.up * 1.4f;
        particlesystemposition.y = particlesystemposition.y - 2.5f;
        
        Vector3 rotation = transform.rotation.eulerAngles;
        Debug.Log(rotation.z);
        if (rotation.z == 90) {
            particlesystem.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (rotation.z == 270) {
            particlesystem.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (rotation.z == 180) {
            particlesystem.transform.rotation = Quaternion.Euler(270, 0, 0);
        } else {
            particlesystem.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        // particlesystem.transform.rotation.x = transform.rotation;
        particlesystem.transform.position = particlesystemposition;
        var em = particlesystem.emission;
        var dur = particlesystem.duration;
        em.enabled = true;
        particlesystem.Play();
        // Destroy (sr);
        // Invoke (nameof(DestroyObj), dur);
        // prog.IncProgressBar(0.05f);
        StartCoroutine(BabyFartDuration(1.0f));
    }

    // void DestroyObj () {
    //     Destroy (gameObject);
    // }

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