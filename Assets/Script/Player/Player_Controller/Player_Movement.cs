using Bang.Lib.StateMachine;
using System.Collections;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D Rb;

    [SerializeField] float speed = 5f;

    [SerializeField] public Vector2 Input_Dir;

    [SerializeField] public float DashForce;
    [SerializeField] float dashingTime = 0.2f;
    [SerializeField] float dashCooldown = 1f;

    public bool IsDashing;
    public bool canDash;
    public bool triggerDash;

    IServiceStopMoving serviceStopMoving;
    IInputVectorService inputMove;
    IInputService inputDash;
    private void Start()
    {
        inputMove = GetComponent<IInputVectorService>();
        inputMove.Subcrible(UpdateInput_Dir);
        inputDash = GetComponent<IInputService>();
        inputDash.Subcrible(UpdateDash);
        serviceStopMoving =GetComponent<IServiceStopMoving>();
        serviceStopMoving.SetRigidbody(Rb);
    }
    public void UpdateInput_Dir(Vector2 dir)
    {
        Input_Dir = dir;
    }
    public void UpdateDash()
    {
        triggerDash = true;
    }
    public void ApplyMovement()
    {
        Vector2 velocity = Input_Dir * speed;
        Rb.linearVelocity = velocity;
    }
    public void DashMovement()
    {
        if (triggerDash)
        {
            if (canDash)
            {
                StartCoroutine(Dash());
            }
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        IsDashing = true;
        Vector2 dashDirection = Input_Dir == Vector2.zero ? new Vector2(transform.localScale.x, 0) : Input_Dir;
        Rb.linearVelocity = dashDirection * DashForce;

        yield return new WaitForSeconds(dashingTime);

        IsDashing = false;
        triggerDash = false;
        serviceStopMoving.StopMoving();

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}
