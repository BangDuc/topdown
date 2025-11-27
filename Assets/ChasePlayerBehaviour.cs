using Bang.Lib.Behaviour_Tree;
using UnityEngine;


public class ChasePlayerBehaviour : MonoBehaviour, IBehaviourNode
{
    IServiceDetectPlayer detectPlayer;
    IChaseService chaseService;

    Monster_Chase_SequenceNode chaseNode;

    [SerializeField]string _id;
    public string ID { get => _id; set => _id= value; }

    public BTNode GetNode()
    {
        return chaseNode;
    }

    void Awake()
    {
        detectPlayer = gameObject.GetComponent<IServiceDetectPlayer>();
        chaseService = gameObject.GetComponent<IChaseService>();
        _id = "Chase_Node";
        chaseNode = new(detectPlayer, chaseService);
    }

    
    
}

public interface IBehaviourNode
{
    string ID { get; set;}
    BTNode GetNode();

}