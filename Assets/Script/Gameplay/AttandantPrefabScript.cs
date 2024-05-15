using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttandantPrefabScript : MonoBehaviour
{
    // [SerializeField] public bool FlightAttendantCollision;
    // [SerializeField] public GameObject flightAttendant;
    private GameObject GameOverScreen = null;

    void Awake()
    {
        GameOverScreen = GameObject.FindGameObjectWithTag("game_over");
        // GameOverScreen.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var collidedObject = collision.gameObject;
        var collider = collision.collider;       

        Debug.Log("Baby is far from initial position!");
        // GameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }


    // private void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log("Enemy collided with the baby!");
    //     // Check if the collided object is the baby prefab
    //     if (collision.gameObject == babyPrefab)
    //     {
    //         Debug.Log("Enemy collided with the baby!");
    //         FlightAttandantCollision = true;
    //     }
    // }

}
