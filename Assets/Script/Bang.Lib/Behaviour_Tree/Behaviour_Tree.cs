using System;
using System.Collections.Generic;
using UnityEngine;
namespace Bang.Lib.Behaviour_Tree
{
    #region Core BT
    public enum NodeState { Success, Failure, Running }


    public abstract class BTNode
    {
        public abstract NodeState Tick();

    }
    public abstract class CompositeNode : BTNode
    {
        protected List<BTNode> children = new();
        public void AddChild(BTNode child) => children.Add(child);
    }

    public class SequenceNode : CompositeNode
    {
        private int current = 0;
        public override NodeState Tick()
        {
            while (current < children.Count)
            {
                var state = children[current].Tick();
                if (state == NodeState.Running) return NodeState.Running;
                if (state == NodeState.Failure)
                {
                    current = 0;
                    return NodeState.Failure;
                }
                // Success -> move to next
                current++;
            }
            current = 0;
            return NodeState.Success;
        }
    }

    public class SelectorNode : CompositeNode
    {
        private int current = 0;
        public override NodeState Tick()
        {
            while (current < children.Count)
            {
                var state = children[current].Tick();
                if (state == NodeState.Running) return NodeState.Running;
                if (state == NodeState.Success)
                {
                    current = 0;
                    return NodeState.Success;
                }
                // Failure -> try next
                current++;
            }
            current = 0;
            return NodeState.Failure;
        }
    }
    #endregion

    #region Leaf Nodes (Condition & Action)
    public class ConditionNode : BTNode
    {
        private Func<bool> condition;
        public ConditionNode(Func<bool> cond) { condition = cond; }
        public override NodeState Tick() => condition() ? NodeState.Success : NodeState.Failure;
    }

    
    public class ActionNode : BTNode
    {
        private Func<NodeState> action;
        public ActionNode(Func<NodeState> act) { action = act; }
        public override NodeState Tick() => action();
    }
    #endregion
}
