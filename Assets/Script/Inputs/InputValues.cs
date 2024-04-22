using UnityEngine;

public struct BoolInputValue : IInputValue<bool>
{
    bool value;

    // Needed a constructor in which we can pass the value
    public BoolInputValue(bool i_value)
    {
        value = i_value;
    }

    public bool Value => value;

    // IsPerformed should be true if the value is true
    public bool IsPerformed => value;
}

public struct Vector2InputValue : IInputValue<Vector2>
{
    Vector2 value;

    // Needed a constructor in which we can pass the value
    public Vector2InputValue(Vector2 i_value)
    {
        value = i_value;
    }

    public Vector2 Value => value;

    // IsPerformed should be true if one of the two axis is != 0
    public bool IsPerformed => value.x != 0 || value.y != 0;
}