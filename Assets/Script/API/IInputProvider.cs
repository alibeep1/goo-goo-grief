using UnityEngine;

public interface IInputProvider
{
    /// <summary>
    /// Gets current button data for a given KeyCode
    /// </summary>
    /// <param name="i_key">The requested KeyCode</param>
    IInputAction<bool> GetButtonData(KeyCode i_key);

    /// <summary>
    /// Gets the curtrent axis data for all movement axis
    /// </summary>
    IInputAction<Vector2> GetAxisData();
}
