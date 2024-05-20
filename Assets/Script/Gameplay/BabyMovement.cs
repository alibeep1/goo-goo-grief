using UnityEngine;

public class BabyMovement : MonoBehaviour
{
    [SerializeField] private InputActionManager inputActions = null;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float inputThreshold = 0.1f; // Threshold to ignore small input values

    private Animator animator;
    private Vector3 moveInput = Vector3.zero;

    private void Start()
    {
        // Subscribe to Axis change events
        inputActions.RegisterToAxisEvents(Axis_Listener);
        animator = GetComponent<Animator>();
    }

void Axis_Listener(IInputAction<Vector2> i_value)
{
    Vector2 axes = inputActions.GetAxisData().GetValue().Value;

    //Debug.Log($"Axes: {axes}");

    // Calculate movement input
    moveInput.x = axes.x * speed * Time.deltaTime;
    moveInput.y = axes.y * speed * Time.deltaTime;

        if (Mathf.Abs(axes.x) > inputThreshold || Mathf.Abs(axes.y) > inputThreshold)
        {
            move(moveInput);
            rotate(moveInput);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
}


    private void rotate(Vector3 i_movement)
    {
        i_movement.Normalize();
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, i_movement);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    private void move(Vector3 i_deltaPosition)
    {
        Vector3 position = transform.position;
        position += i_deltaPosition;
        transform.position = position;
    }
}
