using System;
using UnityEngine;
using UnityEngine.Events;

public class InputVectorService : MonoBehaviour, IInputVectorService
{
    [SerializeField]
    InputReader _inputReader;

    public void Subcrible(UnityAction<Vector2> action)
    {
        _inputReader.MoveEvent += action;
    }

    public void UnSubcrible(UnityAction<Vector2> action)
    {
        _inputReader.MoveEvent -= action;
    }

    void Awake()
    {
        _inputReader = FindAnyObjectByType<InputReader>();
    }

    
}
