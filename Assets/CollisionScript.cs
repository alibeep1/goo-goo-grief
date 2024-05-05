using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float annoyance_inc = 1f;
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

        var collidedObjectScript = collidedObject.GetComponent<passenger>();

        if (collidedObjectScript != null)
        {
            collidedObjectScript.increase_annoyance(annoyance_inc);
        }

        if (collidedObject.name != "Baby")
        {
            Debug.Log($"Collided with {collidedObject.name}");
            
            Destroy(gameObject, 1f);
        }

        //Destroy this object

    }
}
