using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    var collidedObject = collision.gameObject;
    //    var collider = collision.collider;

    //    Debug.Log($"Pee -> Collided with {collidedObject.name}");

    //    // Get the parent object (occupied_seat)
    //    var parentObject = collidedObject?.transform?.parent?.gameObject;

    //    // Get the PassengerHandler child
    //    var passengerHandler = parentObject?.transform?.Find("PassengerHandler").gameObject;

    //    // Get the Passenger Script
    //    var collidedObjectScript = passengerHandler?.GetComponent<passenger>();

    //    if (collidedObjectScript != null)
    //    {
    //        // Increase annoyance of passenger
    //        collidedObjectScript.increase_annoyance(annoyance_inc);
    //    }
    //    else
    //    {
    //        Debug.Log("collidedObjectScript is NULL");
    //    }

    //    // Ignore collisions with the Baby (the player)
    //    if (collidedObject.name != "Baby")
    //    {
    //        Debug.Log($"Collided with {collidedObject.name}");

    //        Destroy(gameObject, 1f);
    //    }
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        var collidedObject = collision.gameObject;
        var collider = collision.collider;

        //Debug.Log($"Pee -> Collided with {collidedObject.name}");


        // Get the Passenger Script
        var collidedObjectScript = collidedObject.GetComponent<passenger>();
        //var parentGameObject = collidedObject.transform.parent.gameObject;

        //var passengerHandler = parentGameObject.transform.Find("PassengerHandler").gameObject;

        //var collidedObjectScript = passengerHandler.GetComponent<passenger>();


        if (collidedObjectScript != null)
        {

            // Increase annoyance of passenger
            collidedObjectScript.increase_annoyance(annoyance_inc);
        }
        else
        {
            Debug.Log("collidedObjectScript is NULL");
        }

        // Ignore collisions with the Baby (the player)
        if (collidedObject.name != "Baby")
        {
            //Debug.Log($"Collided with {collidedObject.name}");

            Destroy(gameObject, 1f);
        }
    }
}
