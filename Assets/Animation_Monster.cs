using Bang.Lib.Behaviour_Tree;
using UnityEngine;

public class Animation_Monster : MonoBehaviour
{
    bool isAttack;
    bool isWalk;
    BehaviourNode BehaviourNode;
    void Update()
    {
        
    }

    private void UpdateAnimation()
    {
        // Lấy Node gốc của hành vi Attack và Chase
        BTNode attackNode = BehaviourNode.Nodes["Attack_Node"].GetNode();
        BTNode chaseNode = BehaviourNode.Nodes["Chase_Node"].GetNode();

        // LOGIC ƯU TIÊN (Priority):

        // 1. Nếu đang Tấn công (Running) -> Chạy anim Attack
        if (attackNode.LastState == NodeState.Running)
        {
            animationControl.ChangeAnimationState(animAttack);
            return;
        }

        // 2. Nếu Attack thất bại (hoặc xong), kiểm tra Chase
        // Nếu đang Chase (Running) -> Chạy anim Walk
        if (chaseNode.LastState == NodeState.Running)
        {
            animationControl.ChangeAnimationState(animWalk);
            return;
        }

        // 3. Nếu cả 2 đều không chạy (Failure hoặc Success) -> Về Idle
        animationControl.ChangeAnimationState(animIdle);
    }
}
}
