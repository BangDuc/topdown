using Bang.Lib.StateMachine;
using System.Collections;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D Rb;

    [SerializeField] float speed = 10f;

    [SerializeField] public Vector2 Input_Dir;

    [SerializeField] public float DashForce;
    [SerializeField] float dashingTime = 0.3f;
    [SerializeField] float dashCooldown = 1f;

    public bool IsDashing;
    public bool canDash;

    IServiceStopMoving serviceStopMoving;
    IInputVectorService inputMove;
    IInputService inputDash;

    [SerializeField]Animation_Controller_Base animation_controller;
    private void Start()
    {
        inputMove = GetComponent<IInputVectorService>();
        inputMove.Subcrible(UpdateInput_Dir);
        inputMove.Subcrible(ApplyMovement);
        inputDash = GetComponent<IInputService>();
        inputDash.Subcrible(DashMovement);
        serviceStopMoving =GetComponent<IServiceStopMoving>();
        serviceStopMoving.SetRigidbody(Rb);
    }
    public void UpdateInput_Dir(Vector2 dir)
    {
        Input_Dir = dir.normalized;
        
    }
    
    public void ApplyMovement(Vector2 dir)
    {
        if (IsDashing) return;
        if (Input_Dir.x != 0)
        {
            
            Player_Manager.Instance.Player.transform.localScale = new Vector3(Mathf.Sign(Input_Dir.x), 1, 1);
        }
        Vector2 velocity = Vector2.ClampMagnitude(dir, 1f) * speed;
        Rb.linearVelocity = velocity;
        
    }
    public void DashMovement()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        IsDashing = true;
        Vector2 dashDirection = Input_Dir;
        Rb.linearVelocity = dashDirection * DashForce;
        animation_controller.ChangeAnimationState(animation_controller.animDash);
        yield return new WaitForSeconds(dashingTime);

        IsDashing = false;
        serviceStopMoving.StopMoving();

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void HandleAnimation()
    {

        if (IsDashing)
        {
            return;
        }
        if (Input_Dir.sqrMagnitude > 0.01f) 
        {
            animation_controller.ChangeAnimationState(animation_controller.animWalk);
            return;
        }
        
      
        animation_controller.ChangeAnimationState(animation_controller.animIdle);
       
    }
    private void Update()
    {
        HandleAnimation();
    }
}
