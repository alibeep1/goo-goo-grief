/// <summary>
/// Input action data provided by an IInputProvider.
/// Describes the state of a given input at this frame.
/// </summary>
/// <typeparam name="T">The type of value associated to the input</typeparam>
struct FrameInputActionData<T> : IInputAction<T> 
{
    IInputValue<T> value;
    bool wasPressedThisFrame;
    bool wasReleasedThisFrame;

    public FrameInputActionData(IInputValue<T> i_value, bool i_wasReleasedThisFrame, bool i_wasPressedThisFrame)
    {
        value = i_value;
        wasPressedThisFrame = i_wasPressedThisFrame;
        wasReleasedThisFrame = i_wasReleasedThisFrame;
    }

    public bool WasPressedThisFrame => wasPressedThisFrame;

    public bool WasReleasedThisFrame => wasReleasedThisFrame;

    // We return the IsPerformed property of the internal value
    public bool IsPerformed => value.IsPerformed;

    public IInputValue<T> GetValue() => value;
}
