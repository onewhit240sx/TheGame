using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveBehaviour : StateMachineBehaviour
{
    public float DiveSpeed;
    
    private Vector3 _DiveTarget;

    private Transform mTarget;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _DiveTarget = mTarget.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float targetDistance = Vector2.Distance(animator.transform.position, mTarget.position);

        if(targetDistance == 0)
        {
            animator.SetBool("isBiting", true);
        }
        else
        {
            animator.SetBool("isBiting", false);
            animator.transform.position =
                Vector2.MoveTowards(animator.transform.position, mTarget.position, DiveSpeed * Time.deltaTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
