using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttandantPrefabScript : MonoBehaviour
{
    // [SerializeField] public bool FlightAttendantCollision;
    // [SerializeField] public GameObject flightAttendant;
    //private GameObject GameOverScreen = null;
    [SerializeField] GameOverScript gameOver = null;


    void Start()
    {
        GameObject gameOverObject = GameObject.FindGameObjectWithTag("game_over");
        gameOver = gameOverObject.GetComponent<GameOverScript>();
        if(gameOver == null)
        {
            Debug.Log("Gameover object is NULL");
        }
        // GameOverScreen.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var collidedObject = collision.gameObject;
        var collider = collision.collider;

        Debug.Log("COLLIDED WITH BABYYYYY");
        if (gameOver == null)
        {
            Debug.Log("Gameover object is NULL");
        }
        else
        {
            Debug.Log("FOUND GAMEOVER OBJECT");

        }

        gameOver.Gameover();
        //gameoverscreen.setactive(true);
        //Time.timeScale = 0;
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
