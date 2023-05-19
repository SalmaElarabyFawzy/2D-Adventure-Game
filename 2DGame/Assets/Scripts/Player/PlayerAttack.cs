using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : StateMachineBehaviour
{

    private PlayerManager manager;
    private bool attack;
    private Vector2 attack_point;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       manager = animator.GetComponent<PlayerManager>();
        attack_point = new Vector2(manager.AttackPoint.position.x, manager.AttackPoint.position.y);
        attack = true;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attack_point, manager.AttackRange,manager.enemy);
        foreach(Collider2D colider in enemies) 
        {
            if(attack && colider!=null)
            {
               colider.GetComponent<EnemyLife>().GetHurt(manager.AttackStrenght);
                attack = false; 

            }
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
