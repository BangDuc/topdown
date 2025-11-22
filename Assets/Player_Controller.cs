using Bang.Lib.StateMachine;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    State_Machine state_Machine;
    [SerializeField]
    Player_Movement player_Movement;

    public Player_Movement Player_Movement { get => player_Movement; set => player_Movement = value; }
    public State_Machine State_Machine { get => state_Machine; set => state_Machine = value; }

    public void SetUpStateMachine()
    {
        state_Machine = new State_Machine();
        state_Machine.AddState("Idle", new IdleStatePlayer(this));
        state_Machine.AddState("Move", new MoveStatePlayer(this));
        state_Machine.AddState("Dash", new DashStatePlayer(this));
        state_Machine.Initialize("Idle");
    }
    private void Start()
    {
        player_Movement = gameObject.GetComponent<Player_Movement>();
        SetUpStateMachine();


    }
    private void Update()
    {
        State_Machine.Execute();
    }

    private void CheckInputChangeState()
    {
        
    }
}
