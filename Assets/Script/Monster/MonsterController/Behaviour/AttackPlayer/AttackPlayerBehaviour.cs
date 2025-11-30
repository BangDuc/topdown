using Bang.Lib.Behaviour_Tree;
using UnityEngine;

public class AttackPlayerBehaviour : MonoBehaviour , IBehaviourNode
{
    IServiceDetectPlayer serviceDetectPlayer;
    IAttackService attackService;

    Monster_Attack_SequenceNode attack_sequenceNode;

    [SerializeField]string _id;
    public string ID { get => _id; set => _id= value; }

    public BTNode GetNode()
    {
        return attack_sequenceNode;
    }

    void Awake()
    {
        serviceDetectPlayer = GetComponent<IServiceDetectPlayer>();
        attackService = GetComponent<IAttackService>();
        _id = "Attack_Node";

        attack_sequenceNode = new Monster_Attack_SequenceNode(serviceDetectPlayer, attackService);
    }
    


}
