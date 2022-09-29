using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationConrol : MonoSingleton<AnimationConrol>
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void CallIdleAnimator()
    {
        animator.Play("idle");
    }
    public void CallRunningAnimtator()
    {
        animator.Play("running");
    }
    public void CallAttackAnimator()
    {
        animator.Play("attack");
    }

}
