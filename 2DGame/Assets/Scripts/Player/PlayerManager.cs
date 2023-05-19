using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float hp = 100;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float speed = 5f;
    public LayerMask ground;
    private Rigidbody2D Rb;
    private BoxCollider2D boxcolid;
    private float dirx;

    [Header("Attack Settings")]
    [SerializeField] private Transform attackpoint;
    [SerializeField] private float attackRange = .5f;
    [SerializeField] private float attackStrenght = 3f;
    private bool attack;


    [Header("Audio")]
    [SerializeField] private AudioSource collectionSound;
    [SerializeField] private AudioSource run_Audio;
    [SerializeField] private AudioSource jumpSound;


    [Header("Text")]
    [SerializeField] private Text kiwiScore;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        boxcolid = GetComponent<BoxCollider2D>();
        attackpoint = transform.GetChild(0);
    }



    public bool Attack
    {
        get { return attack; }
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
    public float Dirx
    { get { return dirx; } }

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
    void Update()
    {
        GetInput();

    }




    private void GetInput()
    {
        dirx = Input.GetAxis("Horizontal");

        Rb.velocity = new Vector2(dirx * speed, Rb.velocity.y);
        attack = Input.GetKeyDown(KeyCode.C);
        if (Input.GetKeyDown(KeyCode.Space) && checkground())
        {
            Rb.velocity = new Vector2(Rb.velocity.x, jumpHeight);
        }
    }



    public bool checkground()
    {
        return Physics2D.BoxCast(boxcolid.bounds.center, boxcolid.bounds.size, 0, Vector2.down, .1f, ground);
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(attackpoint.position, AttackRange);
    }
}
