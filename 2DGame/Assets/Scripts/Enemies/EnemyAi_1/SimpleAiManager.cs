using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAiManager : MonoBehaviour
{

    private EnemyManager enemy;


    [Header("Animation Info")]
    private Animator anim;
    private enum State { idle , patrol , follow , attack };
    private State _state;

    void Start()
    {
        enemy  = GetComponent<EnemyManager>();
        _state = State.patrol;
        anim = GetComponent<Animator>();
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

        anim.SetInteger("state",(int)_state);
    }

}

