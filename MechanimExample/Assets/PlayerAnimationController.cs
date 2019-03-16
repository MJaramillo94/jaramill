using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    #region Attributes

    private Animator animator;


    private const string IDLE_ANIMATION_BOOL = "Idle";
    private const string MOVE_ANIMATION_BOOL = "Move";
    private const string ATTACK_ANIMATION_BOOL = "Attack";
    private const string DIE_ANIMATION_BOOL = "Die";



    #endregion


    #region Animate Functions

    public void AnimateIdle()
    {
        Animate(IDLE_ANIMATION_BOOL);
    }
    public void AnimateMove()
    {
        Animate(MOVE_ANIMATION_BOOL);
    }
    public void AnimateAttack()
    {
        Animate(ATTACK_ANIMATION_BOOL);
    }
    public void AnimateDie()
    {
        Animate(DIE_ANIMATION_BOOL);
    }


    #endregion



    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Animate(string boolName)
    {
        DisableOtherAnimations(animator, boolName);

        animator.SetBool(boolName, true);
    }

    private void DisableOtherAnimations(Animator animator, string animation)
    {
        foreach(AnimatorControllerParameter parameter in  animator.parameters)
        {
            if(parameter.name != animation)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DisableOtherAnimations(animator, "Die");
            animator.SetBool("Die", true);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            DisableOtherAnimations(animator, "Move");
            animator.SetBool("Move", true);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            DisableOtherAnimations(animator, "Attack");
            animator.SetBool("Attack", true);
        }
       else if (Input.GetKeyDown(KeyCode.I))
        {
            DisableOtherAnimations(animator, "Idle");
            animator.SetBool("Idle", true);
        }
    }

}
