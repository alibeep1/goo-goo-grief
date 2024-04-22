using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMovement : MonoBehaviour
{

    [SerializeField] InputActionManager inputActions = null;
    [SerializeField] float speed = 1.0f;

    private Vector3 moveInput = Vector3.zero;
    Vector3 initialPosition; // We cache the intiial position. Useful for reset !

    //DIRECTION inputState = DIRECTION.NONE;


    private void Start()
    {
        initialPosition = transform.position;
        inputActions.RegisterToAxisEvents(Axis_Listener);
        enabled = false; // car controllers are disabled by default. The RaceManager will give them the signal !
    }

    // Update is called once per frame
    void Axis_Listener(IInputAction<Vector2> i_value)
    {

        IInputAction<Vector2> axes = inputActions.GetAxisData();
        moveInput.x = axes.GetValue().Value.x * Time.deltaTime * speed;

        moveInput.y = axes.GetValue().Value.y * Time.deltaTime * speed;

        //moveInput.Normalize();

        move(moveInput);

        //Debug.Log("New Axis value: (" + x_axis + ", " + y_axis + ")");
    }


    // We just increment the transform's position by the given delta
    void move(Vector3 i_deltaPosition)
    {
        Vector3 position = transform.position;
        position += i_deltaPosition;
        transform.position = position;
    }
}
