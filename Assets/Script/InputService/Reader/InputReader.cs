using Bang.Lib.Singleton;
using System;
using UnityEngine;
using UnityEngine.Events;

public class InputReader : Singleton<InputReader>
{
    [SerializeField]
    public Action<Vector2> MoveEvent;
    [SerializeField]
    public Action JumpEvent;

    public void OnMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 InputVector = new Vector2(x, y);
        MoveEvent?.Invoke(InputVector);
    }
    public void OnJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            JumpEvent?.Invoke();
        }
    }
    private void Update()
    {
        OnMove();
        OnJump();
    }

}
