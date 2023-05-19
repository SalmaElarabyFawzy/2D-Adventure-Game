using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowPlayer : StateMachineBehaviour
{
    private Transform player;
    private EnemyManager manager;
    [SerializeField] private float speed = 2;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = animator.GetComponent<EnemyManager>();

        manager.Speed = speed;    
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 dir = new Vector3(player.position.x, animator.transform.position.y, animator.transform.position.z);
        manager.SetRotation(player);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, dir,manager.Speed * Time.deltaTime);
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
