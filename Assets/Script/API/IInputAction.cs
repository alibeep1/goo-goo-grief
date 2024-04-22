public interface IInputAction<T> : IPerformable
{
    /// <summary>
    /// Tells if whether or not the input started being pressed at this frame
    /// </summary>
    bool WasPressedThisFrame {get;}

    /// <summary>
    /// Tells if whether or not the input was released at this frame
    /// </summary>
    bool WasReleasedThisFrame {get;}

    /// <summary>
    /// Gets the value of the input
    /// </summary>
    IInputValue<T> GetValue();
}