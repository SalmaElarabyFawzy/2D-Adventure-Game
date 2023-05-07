using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golbin_attack : StateMachineBehaviour
{
  
    private Vector2 attack_point;
    private GolbinManager golbin;
    public LayerMask _player;
    private bool attack = false;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        golbin = animator.gameObject.GetComponent<GolbinManager>();
        attack_point = new Vector2(golbin.attackPoint.position.x, golbin.attackPoint.position.y);
        attack = true;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        Collider2D palyer = Physics2D.OverlapCircle(attack_point, golbin.attackRange, _player);
        if (palyer != null && attack)
        {
            Debug.Log("Attack");
            golbin.Damage();
            attack = false;
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motions
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

  
}
