using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [Header("Player Info")]
    public LayerMask player_mask;
    private PlayerLife _playerlife;


    [Header("Enemy Info")]
    public GameObject[] path;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float damageAmount;
    private Animator _anim;
    private BoxCollider2D _collider;



    [Header("Attack Info")]

    [SerializeField] private float timeBetweenAttack = 3;
    [SerializeField] private float nextTimeToAttack = 0;
    [SerializeField] private float attackRange = 4f;
    [SerializeField] private float followRange = 8f;

    public Transform AttackPoint
    {
        get { return attackPoint; }
       
    }
    public float Helath
    {
        get { return health; }
    }
    public float NextTimeToAttack
    {
        get { return nextTimeToAttack; }
        set { nextTimeToAttack = value; }
    }
    public float TimeBetweenAttack
    {
        get { return timeBetweenAttack; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public float DamageAmount
    {
        get { return damageAmount; }
    }

    public float MaxSpeed
    {
        get { return MaxSpeed; }
    }
    public BoxCollider2D Collider
    {
        get { return _collider; }
        
    }
    public float AttackRange
    {
        get { return attackRange; }
    }
    public float FollowRange
    {
        get { return followRange; }
    }

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _anim = GetComponent<Animator>();
        attackPoint = transform.GetChild(0);
        _playerlife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }

    public bool checkPlayer(float Distance)
    {
        return (Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0, Vector2.right, Distance ,  player_mask) || Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0, Vector2.left, Distance, player_mask));
    }

    public void GetHurt(float strenght)
    {
        health -= strenght;
        if(health <=.1f)
        {
            Die();
        }
    }

//here
    public void Attack()
    {
        _playerlife.GetHurt(33);  
    }


    private void Die()
    {
        _anim.SetTrigger("Die");
    }

    public void SetRotation(Transform target)
    {
        if (target.position.x < transform.position.x)
        {
           transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (target.position.x > transform.position.x)
        {
           transform.rotation = Quaternion.Euler(0, 0, 0);
        }
       
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
