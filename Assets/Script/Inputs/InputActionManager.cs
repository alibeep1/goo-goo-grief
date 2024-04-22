using UnityEngine;

/// <summary>
/// Implementation of the IInputManager using the Legacy Unity Input System
/// </summary>
public class InputActionManager : MonoBehaviour, IInputManager
{
    private KeyCode[] possibleKeyCodes;
    private IInputAction<Vector2> previousFrameAxisInput;
    private IInputAction<Vector2> currentFrameAxisInput;

    #region UNITY MESSAGES

    void Awake()
    {
        // We initialize cached variables
        previousFrameAxisInput = new FrameInputActionData<Vector2>(new Vector2InputValue(Vector2.zero), false, false);
        currentFrameAxisInput = new FrameInputActionData<Vector2>(new Vector2InputValue(Vector2.zero), false, false);

        // KeyCode is an enum. We can create an array out of all the values of this enum using System.Enum.GetValues
        // https://learn.microsoft.com/en-us/dotnet/api/system.enum.getvalues?view=net-8.0
        // We will use this for our button event (see acquireButtons)
        possibleKeyCodes = (KeyCode[])System.Enum.GetValues(typeof(KeyCode));
    }

    void Update()
    {
        acquireInputs();
    }

    // OnDisable will be called automatically by unity when we disable the component. We can reset some variables here
    // https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDisable.html
    void OnDisable()
    {
        previousFrameAxisInput = new FrameInputActionData<Vector2>(new Vector2InputValue(Vector2.zero), false, false);
        currentFrameAxisInput = new FrameInputActionData<Vector2>(new Vector2InputValue(Vector2.zero), false, false);
    }

    #endregion

    #region IInputManager

    // We can use the built-in "enabled" property of the component, as it will automatically stop / start any calls to update
    // https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html
    public void DisableInputs()
    {
        enabled = false;
    }

    public void EnableInputs()
    {
        enabled = true;
    }

    public IInputAction<Vector2> GetAxisData()
    {
        // This is computed at every frame in the acquireAxis function. We can simply return it here.
        // We also reset this variable on OnDisable. Therefore, we are assured that if the inputs are indeed disabled,
        // it will also return a correct value. 
        return currentFrameAxisInput;
    }

    public IInputAction<bool> GetButtonData(KeyCode i_key)
    {
        // GetKey returns true if the key is currently being pressed
        // https://docs.unity3d.com/ScriptReference/Input.GetKeyUp.html
        bool isPerformed = Input.GetKey(i_key);
        // GetKeyUp returns true if the key is was released this frame
        // https://docs.unity3d.com/ScriptReference/Input.GetKey.html
        bool wasReleasedThisFrame = Input.GetKeyUp(i_key);
        // GetKeyDown returns true if the key started being pressed this frame
        // https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html
        bool wasPressedThisFrame = Input.GetKeyDown(i_key);

        return new FrameInputActionData<bool>(new BoolInputValue(isPerformed), wasReleasedThisFrame, wasPressedThisFrame);
    }

    #endregion

    #region Event API 

    // These delegate declarations define the signature of the events. Callbacks to these events must abide by these signatures.
    // https://learn.unity.com/tutorial/delegates#5c894658edbc2a0d28f48aee
    public delegate void ButtonEvent(IInputAction<bool> i_value, KeyCode i_keyCode);
    public delegate void AxisEvent(IInputAction<Vector2> i_value);

    // This event will be fired whenever a button is being "performed" (ANY button)
    ButtonEvent onButtonEvent;
    // This event will be fired whenever the axis are being "performed" 
    AxisEvent onAxisEvent;

    public void RegisterToInputEvents(ButtonEvent i_buttonCallback, AxisEvent i_axisCallback)
    {
        // This is how we register callbacks to events. 
        onButtonEvent += i_buttonCallback;
        onAxisEvent += i_axisCallback;
    }
    public void RegisterToAxisEvents(AxisEvent i_axisCallback)
    {
        // This is how we register callbacks to events. 
        //onButtonEvent += i_buttonCallback;
        onAxisEvent += i_axisCallback;
    }

    #endregion

    #region PRIVATE

    void acquireInputs()
    {
        // We split acquireInputs into two functions because we like to keep things neat
        acquireAxis();
        acquireButtons();
    }

    void acquireAxis()
    {
        // We cache the input that was acquired at the previous frame
        previousFrameAxisInput = currentFrameAxisInput;

        // We read both axis for this frame
        // https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 axisInput = new Vector2(horizontal, vertical);

        // true is the previous frame input was performed and both axis are zero at the current frame. false otherwise
        bool wasReleasedThisFrame = (previousFrameAxisInput.IsPerformed == true && axisInput.x == 0 && axisInput.y == 0);

        // true is the previous frame input was not performed and at least one axis is not zero at the current frame. false otherwise
        bool wasPressedThisFrame = (previousFrameAxisInput.IsPerformed == false && (axisInput.x != 0 || axisInput.y != 0));

        // we have everything we need to populate the new input data 
        currentFrameAxisInput = new FrameInputActionData<Vector2>(new Vector2InputValue(axisInput), wasReleasedThisFrame, wasPressedThisFrame);

        // We choose to dispatch the event only if the input is being performed...
        if (currentFrameAxisInput.IsPerformed)
        {
            // Always check an event isn't null before triggering ! Triggering null events leads to crashes.
            // This will call anonymously all functions that were registered to this event (listeners)
            if (onAxisEvent != null) onAxisEvent(currentFrameAxisInput);
        }
    }

    void acquireButtons()
    {
        // We don't event want to enter this scope is no key is being performed
        // https://docs.unity3d.com/ScriptReference/Input-anyKeyDown.html
        if (Input.anyKeyDown == false) return;
        // We don't want to enter this scope either if the onButtonEvent has no listeners. The entire purpose of this function
        // is to trigger this event
        if (onButtonEvent == null) return;

        int count = possibleKeyCodes.Length; // It is good practice to cache the count of an array, so that the Length property wouldn't be accessed at each iteration (slow)

        // Unfortunately, the legacy input system doesn't really let us know out of the box
        // if any key is pressed. For this, we need to implement our own loop and check all the key codes.
        // You will rarely need to do this in games (unless you give the players the option to remap their inputs).
        // In most cases, you will have decided of your inputs and what actions they are mapped to. You would only need to loop through these.
        for (int i = 0; i < count; i++)
        {
            KeyCode keyCode = possibleKeyCodes[i];

            // if the key is performed, we can trigger our event with the proper parameters
            if (Input.GetKey(keyCode))
            {
                onButtonEvent(GetButtonData(keyCode), keyCode);
            }
        }
    }

    #endregion
}
