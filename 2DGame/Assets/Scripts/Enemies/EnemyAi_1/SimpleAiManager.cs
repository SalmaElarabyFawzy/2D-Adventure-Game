using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAiManager : MonoBehaviour
{

    private EnemyManager enemy;
    private AnimationContrlle animator;
    public  enum State { idle , patrol , follow , attack , hurt };
    private State _state;

    void Start()
    {
        enemy  = GetComponent<EnemyManager>();
        _state = State.patrol;
        animator = GetComponent<AnimationContrlle>();
       
    }

    void Update()
    {

        if(enemy.checkPlayer(enemy.AttackRange))
        {
            if (Time.time > enemy.NextTimeToAttack)
            {

               _state = State.attack;
                enemy.NextTimeToAttack = Time.time + enemy.TimeBetweenAttack;
            }
            else
            {
                _state = State.idle;
            }

        }
        else if( enemy.checkPlayer(enemy.FollowRange))
        {
            _state= State.follow;
            
        }
        else
        {
            _state = State.patrol;
            
        }
         animator.Anim.SetInteger("state" ,(int) _state);
        // animator.Anim.Play(animator.AnimationNames((int)_state));
    }

}

