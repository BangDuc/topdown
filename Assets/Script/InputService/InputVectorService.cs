using System;
using UnityEngine;
using UnityEngine.Events;

public class InputVectorService : MonoBehaviour, IInputVectorService
{
    public void Subcrible(Action<Vector2> action)
    {
        InputReader.Instance.MoveEvent += action;
    }

    public void UnSubcrible(Action<Vector2> action)
    {
        InputReader.Instance.MoveEvent -= action;
    }
    
}
