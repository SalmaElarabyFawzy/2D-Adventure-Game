using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class PatrolEnemy : StateMachineBehaviour
{
    private EnemyManager manager;

    [SerializeField] private int currentPoint = 0;
    [SerializeField] private float speed = 1.5f;
    
    private Vector3 target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        manager = animator.gameObject.GetComponent<EnemyManager>();
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
        target = new Vector3 (manager.path[currentPoint].transform.position.x , animator.transform.position.y,animator.transform.position.z);
        manager.SetRotation(manager.path[currentPoint].transform);
        animator.gameObject.transform.position = Vector2.MoveTowards(animator.gameObject.transform.position, target, speed * Time.deltaTime);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
