
using Bang.Lib.StateMachine;
using UnityEngine;

public class IdleStatePlayer : IState
{
    Player_Controller controller;

    public IdleStatePlayer(Player_Controller controller)
    {
        this.controller = controller;
    }

    public void Enter()
    {
        Debug.Log("Enter Idle State");
    }

    public void Exit()
    {
        Debug.Log("Exit Idle State");
    }

    public void Update()
    {
        if(controller.Player_Movement.Input_Dir != Vector2.zero)
        {
            controller.State_Machine.ChangeState("Move");
        }
    }
}
public class MoveStatePlayer : IState
{
    Player_Controller controller;

    public MoveStatePlayer(Player_Controller controller)
    {
        this.controller = controller;
    }

    public void Enter()
    {
        Debug.Log("Enter MoveState");
    }

    public void Exit()
    {
        
        Debug.Log("Exit MoveState");
    }

    public void Update()
    {
        if (controller.Player_Movement.Input_Dir == Vector2.zero)
        {
            controller.State_Machine.ChangeState("Idle");
        }
        if (controller.Player_Movement.triggerDash == true)
        {
            controller.State_Machine.ChangeState("Dash");
        }
        controller.Player_Movement.ApplyMovement();
    }
}
public class DashStatePlayer : IState
{
    Player_Controller controller;

    public DashStatePlayer(Player_Controller controller)
    {
        this.controller = controller;
    }

    public void Enter()
    {
        Debug.Log("Enter DashState");
    }

    public void Exit()
    {
        Debug.Log("Exit DashState");
    }

    public void Update()
    {
        controller.Player_Movement.DashMovement();
        controller.State_Machine.ChangeState("Idle");
    }
}