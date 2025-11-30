using Bang.Lib.Behaviour_Tree;


public class Monster_Chase_SequenceNode : SequenceNode
{

    public Monster_Chase_SequenceNode(IServiceDetectPlayer serviceDetectPlayer, IChaseService chasePlayer)
    {
        
        AddChild(new CheckPlayerDetect_Node(serviceDetectPlayer, chasePlayer));
        AddChild(new ChasePlayer_Node(serviceDetectPlayer, chasePlayer));
    }
}
public class CheckPlayerDetect_Node: BTNode
{
    IServiceDetectPlayer serviceDetectPlayer;
    IChaseService servicechase;

    public CheckPlayerDetect_Node(IServiceDetectPlayer serviceDetectPlayer, IChaseService servicechase)
    {
        this.serviceDetectPlayer = serviceDetectPlayer;
        this.servicechase = servicechase;
    }

    public override NodeState Tick()
    {
       if( serviceDetectPlayer.isDetect()) return NodeState.Success;
        servicechase.Stop();
       return NodeState.Failure;
    }
}
public class ChasePlayer_Node : BTNode
{
    IServiceDetectPlayer serviceDetectPlayer;
    IChaseService chasePlayer;

    public ChasePlayer_Node(IServiceDetectPlayer serviceDetectPlayer, IChaseService chasePlayer)
    {
        this.serviceDetectPlayer = serviceDetectPlayer;
        this.chasePlayer = chasePlayer;
        
    }

    public override NodeState Tick()
    {
        chasePlayer.Chase(serviceDetectPlayer.GetPlayer());
        return NodeState.Running;
    }
}



