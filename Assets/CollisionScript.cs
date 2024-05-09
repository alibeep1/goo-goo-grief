using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] float annoyance_inc = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var collidedObject = collision.gameObject;
        var collider = collision.collider;

        Debug.Log($"Collided with {collidedObject.name}");

        if (collidedObject.name == "Baby" && collider is CircleCollider2D)
        {
            Debug.Log("Collided with baby's circle collider...");
            return;
        }
        // Get the Passenger Script
        var collidedObjectScript = collidedObject.GetComponent<passenger>();

        if (collidedObjectScript != null)
        {
            // Increase annoyance of passenger
            collidedObjectScript.increase_annoyance(annoyance_inc);
        }

        // Ignore collisions with the Baby (the player)
        if (collidedObject.name != "Baby")
        {
            Debug.Log($"Collided with {collidedObject.name}");

            Destroy(gameObject, 1f);
        }

        //Destroy this object

    }
}
