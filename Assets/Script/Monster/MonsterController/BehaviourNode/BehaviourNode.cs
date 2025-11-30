using Bang.Lib.Behaviour_Tree;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourNode : MonoBehaviour
{
    SelectorNode SelectorNode;

    public Dictionary<string,IBehaviourNode> Nodes = new();
    private void Awake()
    {
        SelectorNode = new SelectorNode();

       
    }
    private void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.TryGetComponent<IBehaviourNode>(out var behaviourNode);
            Nodes.Add(behaviourNode.ID, behaviourNode);
        }

        SelectorNode.AddChild(Nodes["Attack_Node"].GetNode());
        SelectorNode.AddChild(Nodes["Chase_Node"].GetNode());
    }
    private void Update()
    {
        SelectorNode.Tick();
        
    }

}

