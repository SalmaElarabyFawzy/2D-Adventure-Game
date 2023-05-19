using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyingEyePlayerFollow : StateMachineBehaviour
{
    private Transform Player;
    private SpriteRenderer _sprite;
    [SerializeField] private float speed = 2f;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        _sprite = animator.GetComponent<SpriteRenderer>();
    
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Player.position.x < animator.transform.position.x)
        {
            _sprite.flipX = true;
        }
        else if (Player.position.x >animator.transform.position.x)
        {
            _sprite.flipX = false;

        }
       
       animator.gameObject.transform.position = Vector2.MoveTowards(animator.transform.position, Player.position, speed * Time.deltaTime);

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
