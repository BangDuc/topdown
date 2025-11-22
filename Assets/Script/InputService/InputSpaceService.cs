using System;
using UnityEngine;

public class InputSpaceService : MonoBehaviour, IInputService
{
    
    public void Subcrible(Action action)
    {
        if (action == null) return;
        InputReader.Instance.JumpEvent += action;
    }

    public void UnSubcrible(Action action)
    {
        if (action == null) return;
        InputReader.Instance.JumpEvent -= action;
    }
}
