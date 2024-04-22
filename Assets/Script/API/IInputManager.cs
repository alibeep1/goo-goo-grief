public interface IInputManager : IInputProvider
{
    /// <summary>
    /// Enables the input acquisition
    /// </summary>
    void EnableInputs();

    /// <summary>
    /// Disables the input acquisition
    /// </summary>
    void DisableInputs();
}