using System;
using UnityEngine;

public interface IInputVectorService
{
    void Subcrible(Action<Vector2> action);
    void UnSubcrible(Action<Vector2> action);

}
