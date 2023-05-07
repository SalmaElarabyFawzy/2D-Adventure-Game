using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class PatrolGolbin : StateMachineBehaviour
{
    private GolbinManager manager;
   
    [SerializeField] private int currentPoint = 0;
    [SerializeField] private float speed = 4;
    private SpriteRenderer _sprite;
    private Vector3 target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         manager = animator.gameObject.GetComponent<GolbinManager>();
        _sprite = animator.gameObject.GetComponent<SpriteRenderer>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        


        float dis = Vector2.Distance(manager.path[currentPoint].transform.position, animator.gameObject.transform.position);
           
        if (dis < .1f)
        {
          
            currentPoint++;
            if (currentPoint >= manager.path.Length)
            {
                currentPoint = 0;
            }
        }
        target = manager.path[currentPoint].transform.position;
        if(target.x > animator.gameObject.transform.position.x)
        {
            _sprite.flipX = false;
        }
        else if(target.x < animator.gameObject.transform.position.x)
        {
            _sprite.flipX= true;
        }
        animator.gameObject.transform.position = Vector2.MoveTowards(animator.gameObject.transform.position,target, speed * Time.deltaTime);
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
