using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeMechanism : MonoBehaviour
{

    [SerializeField] InputActionManager inputActions = null;
    [SerializeField] float pee_distance = 20f;
    [SerializeField] float secondsAlive = 3f;

    [SerializeField] GameObject missilePrefab = null;

    [SerializeField] float missileSpeed = 0.7f;
    [SerializeField] ProgressBar prog = null;

    [SerializeField] AudioClip peeSound = null;
    private AudioSource audioSource = null;

    public void PlayPeeSound()
    {
        if (audioSource != null)
        {

            audioSource.PlayOneShot(peeSound);
        }
        else
        {
            Debug.Log("AudioSource IS NULL");
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

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
            PlayPeeSound();
            StartCoroutine(DestroyAfterDistance(missileObject, secondsAlive));
        }



    }
    IEnumerator DestroyAfterDistance(GameObject missileObject, float secondsAlive)
    {
        // Calculate the time it takes for the missile to travel the maximum distance
        // Stop the missile's motion
        Rigidbody2D missile = missileObject.GetComponent<Rigidbody2D>();

        float travelTime = pee_distance / missileSpeed;

        // Wait for the travel time
        yield return new WaitForSeconds(travelTime);
        if (missile != null)
        {
            missile.velocity = Vector2.zero;
        }
        
        yield return new WaitForSeconds(secondsAlive);
        // Destroy the missile
        Destroy(missileObject);
    }
}
