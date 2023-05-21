using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    [Header("Enemy Info")]
    [SerializeField] private LayerMask enemy;




    [Header("Player Settings")]
    [SerializeField] private float hp = 100;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private LayerMask ground;
    private Rigidbody2D Rb;
    private BoxCollider2D boxcolid;
    




    [Header("Attack Settings")]
    [SerializeField] private Transform attackpoint;
    [SerializeField] private float attackRange = .5f;
    [SerializeField] private float attackStrenght = 3f;
    


    [Header("Audio")]
    [SerializeField] private AudioSource collectionSound;
    [SerializeField] private AudioSource run_Audio;
    [SerializeField] private AudioSource jumpSound;


    [Header("Text")]
    [SerializeField] private Text kiwiScore;



    [Header("Animation")]
    private Animator anim;


    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        boxcolid = GetComponent<BoxCollider2D>();
        attackpoint = transform.GetChild(0);
        anim = GetComponent<Animator>();
    }


    public Animator Animator
    {
        get { return anim; }
    }
   
    public Transform AttackPoint
    {
        get { return attackpoint; } 
    }
    public Rigidbody2D RB
    {
        get { return Rb; }
    }
    public BoxCollider2D Boxcolid
    {
        get { return boxcolid; }
    }
   

    public float JumpHeight
    {
        get { return jumpHeight; }
    }

    public AudioSource CollectionSound
    {
        get { return collectionSound; }
    }
    public AudioSource Run_Audio
    {
        get { return run_Audio; }
    }
    public AudioSource JumpSound
    {
        get { return jumpSound; }
    }

    public Text KiwiScore
    {
        get { return kiwiScore; }
    }
    public float HP
    {
        get { return hp; }
        set { hp = value; }
    }
    public float AttackRange
    {
        get { return attackRange; } 
    }
    public float AttackStrenght
    {
        get { return attackStrenght; }
    }
    public float Speed
    {
        get { return speed; }
    }
    public LayerMask Ground
    {
        get { return ground; }
    }
    public LayerMask Enemy
    {
        get { return enemy; }
    }
    void Update()
    {
  

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(attackpoint.position, AttackRange);
    }
}
