using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyaway : StateMachineBehaviour
{
    private FlighteyeManager _flyingEye;
    [SerializeField] private Vector2 point1 = new Vector2(0, 0);
    [SerializeField] private Vector2 point2 = new Vector2(0, 1);
    private int currentPoint = 0;
    private Transform currentPos ;
    private Vector2 pos;
    [SerializeField] private float speed = 7f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentPos = animator.gameObject.transform;
        _flyingEye = animator.GetComponent<FlighteyeManager>();
         pos = new Vector2 (animator.transform.position.x , animator.transform.position.y);    
    }
    
        
    

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
       if(Vector2.Distance(animator.transform.position , pos) <.1f)
        {
            currentPoint++;
            if(currentPoint>=_flyingEye.points.Length) 
            {
                currentPoint = 0;
            }
             pos = new Vector2(animator.transform.position.x + _flyingEye.points[currentPoint].x, animator.transform.position.y + _flyingEye.points[currentPoint].y);
        }
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, pos, speed*Time.deltaTime);

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
