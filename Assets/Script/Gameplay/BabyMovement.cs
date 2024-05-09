using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMovement : MonoBehaviour
{

    [SerializeField] InputActionManager inputActions = null;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float rotationSpeed = 1.0f;

    private Vector3 moveInput = Vector3.zero;

    private void Start()
    {
        // Subscribe to Axis change events
        inputActions.RegisterToAxisEvents(Axis_Listener);
    }

    // Update is called once per frame
    void Axis_Listener(IInputAction<Vector2> i_value)
    {

        IInputAction<Vector2> axes = inputActions.GetAxisData();

        moveInput.x = axes.GetValue().Value.x * Time.deltaTime * speed;

        moveInput.y = axes.GetValue().Value.y * Time.deltaTime * speed;

        move(moveInput);

        rotate(moveInput);
    }

    private void rotate(Vector3 i_movement)
    {
        moveInput.Normalize();

        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, i_movement);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }


    // We just increment the transform's position by the given delta
    void move(Vector3 i_deltaPosition)
    {
        Vector3 position = transform.position;
        position += i_deltaPosition;
        transform.position = position;
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    var collidedObject = collision.gameObject;
    //    var collider = collision.collider;

    //    Debug.Log($"Baby collided with {collidedObject.name}");

    //    if (collidedObject.name == "occupied_seat(Clone)" && collider is CircleCollider2D)
    //    {
    //        Debug.Log("Collided with baby's circle collider...");
    //        return;
    //    }
    //}
}
