using UnityEngine;

public class Animation_Controller_Base2 : MonoBehaviour, IAnimationControl
{
    [SerializeField] public Animator animator;

    private int currentAnimState;

    public int animWalk = Animator.StringToHash("Walk");
    public int animAttack = Animator.StringToHash("Attack");

    public void ChangeAnimationState(int newState)
    {
        if (currentAnimState == newState) return;

        animator.Play(newState);
        currentAnimState = newState;
    }

}
