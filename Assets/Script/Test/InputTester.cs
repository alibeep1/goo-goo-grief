using UnityEngine;

public class InputTester : MonoBehaviour
{
    [SerializeField] InputActionManager inputActions = null;

    // Here, we add a few options so we can choose what we log and not.
    // This will facilitate our testing, as the console could quikcly get cluttered with logs ! 
    [SerializeField] bool logButtonEventCallback = true; 
    [SerializeField] bool logAxisEventCallback = true;
    [SerializeField] KeyCode testKey = KeyCode.A; // We can set a key to test in the inspector
    [SerializeField] bool logTestKeyInUpdate = true;
    [SerializeField] bool logAxisAcquisitionInUpdate = true;

    private void Awake()
    {
        if(inputActions != null) 
        {
            // We register our callbacks, which will log to the console whenever the events are fired
            inputActions.RegisterToInputEvents(onButtonEvent, onAxisEvent);
        }
    }

    private void Update()
    {
        IInputAction<bool> enableInputs = inputActions.GetButtonData(KeyCode.Return); // Key down on return will enable the input manager
        IInputAction<bool> disableInputs = inputActions.GetButtonData(KeyCode.Backspace); // Key down on backspace will disable the input manager

        if(enableInputs.WasPressedThisFrame)
        {
            inputActions.EnableInputs();
            Debug.Log("Did enable inputs");
        }
        else if (disableInputs.WasPressedThisFrame)
        {
            inputActions.DisableInputs();
            Debug.Log("Did disable inputs");
        }

        if(inputActions.enabled)
        {
            if(logTestKeyInUpdate == true)
            {
                IInputAction<bool> buttonInput = inputActions.GetButtonData(testKey);

                if(buttonInput.IsPerformed || buttonInput.WasPressedThisFrame || buttonInput.WasReleasedThisFrame)
                    logInputAction(buttonInput);
            }


            if(logAxisAcquisitionInUpdate == true)
            {
                IInputAction<Vector2> axisInput = inputActions.GetAxisData();

                if (axisInput.IsPerformed || axisInput.WasPressedThisFrame || axisInput.WasReleasedThisFrame)
                    logInputAction(axisInput);
            }

        }
    }

    // Button event callback. Follows the signature forced by the ButtonEvent delegate
    void onButtonEvent(IInputAction<bool> i_value, KeyCode i_keyCode)
    {
        if (logButtonEventCallback == false) return;

        Debug.Log("onButtonEvent !!! " + i_keyCode);
        logInputAction(i_value);
    }

    // Axis event callback. Follows the signature forced by the AxisEvent delegate
    void onAxisEvent(IInputAction<Vector2> i_value)
    {
        if(logAxisEventCallback == false) return;

        Debug.Log("onAxisEvent !!!");
        logInputAction(i_value);
    }

    // Utility function to log an IInputAction. We make this function a generic so that we don't need to duplicate code
    void logInputAction<T>(IInputAction<T> i_value)
    {
        Debug.Log(
            "InputType : " + typeof(T) +
            " Value : " + i_value.GetValue().Value + 
            " IsPerformed : " + i_value.IsPerformed + 
            " WasPressedThisFrame : " + i_value.WasPressedThisFrame + 
            " WasReleasedThisFrame : " + i_value.WasReleasedThisFrame);
    }
}