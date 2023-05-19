using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyattack : StateMachineBehaviour
{
  
    private Vector2 attack_point;
    private EnemyManager golbin;
    public LayerMask _player;
    private bool attack = false;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        golbin = animator.gameObject.GetComponent<EnemyManager>();
        attack_point = new Vector2(golbin.AttackPoint.position.x, golbin.AttackPoint.position.y);
        attack = true;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        Collider2D palyer = Physics2D.OverlapCircle(attack_point, golbin.AttackRange, _player);
        if (palyer != null && attack)
        {
            Debug.Log("Attack");
            golbin.Attack();
            attack = false;
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }



  
}
