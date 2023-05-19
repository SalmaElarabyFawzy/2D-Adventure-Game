using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : StateMachineBehaviour
{

    private PlayerManager manager;
    private Collider2D[] enemies;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       manager = animator.GetComponent<PlayerManager>();    
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemies = Physics2D.OverlapCircleAll(manager.AttackPoint.position, manager.AttackRange);
        foreach(Collider2D colider in enemies) 
        {

        }
    }


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
