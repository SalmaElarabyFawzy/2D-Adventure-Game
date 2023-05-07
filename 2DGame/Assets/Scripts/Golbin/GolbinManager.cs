using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolbinManager : MonoBehaviour
{
    [Header("Player Info")]
    public Transform player;
    public LayerMask player_mask;
    private PlayerLife player_life;


    [Header("Animation Info")]
    private Animator anim;
    public GameObject[] path;
    private enum State { idle , patrol , follow , attack , die};
    private State _state;

    [Header("Attack Info")]
    private float TimeBetweenAttack = 3;
    private float NextTimeToAttack = 0;
    public float attackRange = 4f;
    public Transform attackPoint; 


    public float away_distance = 4f;
    private BoxCollider2D colid;
   
    void Start()
    {
        _state = State.patrol;
        anim = GetComponent<Animator>();
        colid = GetComponent<BoxCollider2D>();
        player_life = FindObjectOfType<PlayerLife>();
        attackPoint = transform.GetChild(0);
    }


    void Update()
    {
       PlayerPos(player.position);
        
        float dis = Vector2.Distance(transform.position, player.transform.position);


        if(Attack())
        {
            if (Time.time > NextTimeToAttack)
            {

               _state = State.attack;
                NextTimeToAttack = Time.time + TimeBetweenAttack;
            }
            else
            {
                _state = State.idle;
            }

        }
        else if( checkPlayer())
        {
            _state= State.follow;
            
        }
        else
        {
            _state = State.patrol;
        }

        anim.SetInteger("state",(int)_state);
    }

    private bool checkPlayer()
    {
        return (Physics2D.BoxCast(colid.bounds.center, colid.bounds.size, 0, Vector2.right, away_distance, player_mask) || Physics2D.BoxCast(colid.bounds.center, colid.bounds.size, 0, Vector2.left, away_distance, player_mask));
    }


    public void Damage()
    {
        player_life.Die();
    }


    private bool Attack()
    {
        return (Physics2D.BoxCast(colid.bounds.center, colid.bounds.size, 0, Vector2.right, attackRange/2, player_mask) || Physics2D.BoxCast(colid.bounds.center, colid.bounds.size, 0, Vector2.left, attackRange/2, player_mask));
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void PlayerPos ( Vector3 pos)
    {
        Debug.Log(pos);
    }
}

