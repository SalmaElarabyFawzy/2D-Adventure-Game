using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightEyeIdle : StateMachineBehaviour
{
    private FlighteyeManager eye;
    [SerializeField] private float speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      eye = animator.gameObject.GetComponent<FlighteyeManager>();
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // animator.gameObject.transform.position = Vector2.MoveTowards(animator.gameObject.transform.position, eye.SetPosition, speed*Time.deltaTime);
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
