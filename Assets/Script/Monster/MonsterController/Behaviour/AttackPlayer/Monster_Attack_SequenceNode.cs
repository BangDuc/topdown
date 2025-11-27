using Bang.Lib.Behaviour_Tree;
using UnityEngine;

public class Monster_Attack_SequenceNode : SequenceNode
{
    CheckPlayerNear_Node checkPlayerNear_Node;
    CheckCanAttack_Node checkCanAttack_Node;
    AttackPlayer_Node attackPlayer_Node;

    IServiceDetectPlayer DetectPlayerNear;
    IAttackService Attackservice;

    public Monster_Attack_SequenceNode(IServiceDetectPlayer detectPlayerNear, IAttackService attackservice)
    {
        DetectPlayerNear = detectPlayerNear;
        Attackservice = attackservice;

        checkPlayerNear_Node = new CheckPlayerNear_Node(DetectPlayerNear);
        checkCanAttack_Node = new CheckCanAttack_Node(Attackservice);
        attackPlayer_Node = new AttackPlayer_Node(DetectPlayerNear, Attackservice);

        AddChild(checkPlayerNear_Node);

        AddChild(checkCanAttack_Node);

        AddChild(attackPlayer_Node);
    }

}

public class CheckPlayerNear_Node :BTNode
{
    IServiceDetectPlayer DetectPlayerNear;

    public CheckPlayerNear_Node(IServiceDetectPlayer detectPlayerNear)
    {
        DetectPlayerNear = detectPlayerNear;
    }

    public override NodeState Tick()
    {
        if(DetectPlayerNear.isDetect()) return NodeState.Success;
        return NodeState.Failure;
    }
}
public class CheckCanAttack_Node : BTNode
{
    IAttackService attackservice;

    public CheckCanAttack_Node(IAttackService attackservice)
    {
        this.attackservice = attackservice;
    }

    public override NodeState Tick()
    {
        if (attackservice.CanAttack()) return NodeState.Success;
        return NodeState.Failure;
    }
}

public class AttackPlayer_Node : BTNode
{
    IServiceDetectPlayer serviceDetectPlayer;
    IAttackService attackservice;

    public AttackPlayer_Node(IServiceDetectPlayer serviceDetectPlayer, IAttackService attackservice)
    {
        this.serviceDetectPlayer = serviceDetectPlayer;
        this.attackservice = attackservice;
    }

    public override NodeState Tick()
    {
        attackservice.Attack(serviceDetectPlayer.GetPlayer());
        return NodeState.Running;

    }
}