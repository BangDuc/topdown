using System;
using UnityEngine;
using UnityEngine.Events;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D Rb;
    [SerializeField] float speed = 5f;
    IInputVectorService input;
    private void Start()
    {
        input = GetComponent<IInputVectorService>();
        input.Subcrible(ApplyMovement);
    }

    void ApplyMovement(Vector2 dir)
    {
        Vector2 velocity = dir * speed;
        Rb.linearVelocity = velocity;
    }
}

public interface IInputVectorService
{
    void Subcrible(UnityAction<Vector2> action);
    void UnSubcrible(UnityAction<Vector2> action);

}
public interface IInputService
{
    void Subcrible(Action action);
    void UnSubcrible(Action action);
}
