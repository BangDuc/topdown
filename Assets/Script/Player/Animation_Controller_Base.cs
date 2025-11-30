using UnityEngine;

public class Animation_Controller_Base : MonoBehaviour
{
    [SerializeField]public Animator animator;

    private int currentAnimState;

    public int animWalk = Animator.StringToHash("Walk");
    public int animIdle = Animator.StringToHash("Idle");
    public int animDash = Animator.StringToHash("Dash");

    public void ChangeAnimationState(int newState)
    {
        if (currentAnimState == newState) return; 

        animator.Play(newState);
        currentAnimState = newState;
    }

}
