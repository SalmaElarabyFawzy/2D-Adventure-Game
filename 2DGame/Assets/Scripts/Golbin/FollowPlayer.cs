using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : StateMachineBehaviour
{
    private Transform player;
    [SerializeField] private float speed = 2f;
    private SpriteRenderer _sprite;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _sprite = animator.GetComponent<SpriteRenderer>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Vector3 dir = new Vector3(player.position.x, animator.transform.position.y, animator.transform.position.z);
        if(player.position.x < animator.transform.position.x) 
        {
            _sprite.flipX = true;
        }
        else if(player.position.x > animator.transform.position.x)
        {
            _sprite.flipX = false;
        }
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, dir, speed*Time.deltaTime);
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
