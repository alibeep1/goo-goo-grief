using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnnoyingMoves : MonoBehaviour
{

    [SerializeField] InputActionManager inputActions = null;
    [SerializeField] float pee_distance = 20f;

    [SerializeField] GameObject missilePrefab = null;
    [SerializeField] float missileSpeed = 0.7f;
    [SerializeField] ProgressBar prog;


    // Start is called before the first frame update
    private void Start()
    {
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
        }
        prog.IncProgressBar(0.05f);

    }


}
