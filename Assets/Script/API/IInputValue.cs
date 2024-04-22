using UnityEngine;

public interface IInputValue<T> : IPerformable
{
    public T Value {get;}
}
