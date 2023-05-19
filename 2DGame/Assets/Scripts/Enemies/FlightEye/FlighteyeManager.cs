using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlighteyeManager : MonoBehaviour
{

    private Transform Player;
    public BoxCollider2D colider;
    public Vector3 SetPosition;
    public Vector3[] points;
    //  [SerializeField] private float distance;
    [Header("Animation")]
     public float speed = 2f;
     private Animator anim;
     private enum State { idle , follow , attack , flyaway , death};
     private State _state;
    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float followDistance = 5f;
    private float TimeBetweenAttack = 10;
    private float NextTimeToAttack = 0;

    void Start()
    {
        SetPosition = transform.position;
        colider = gameObject.GetComponent<BoxCollider2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        anim  = GetComponent<Animator>();
        _state= State.idle;
      
    }

    // Update is called once per frame
    void Update()
    {
        AnimationStates();
       
    }

    private void AnimationStates()
    {
        
        float dis = Vector2.Distance(transform.position, Player.position);

        if (dis <= attackDistance)
        {
            if(Time.time >= NextTimeToAttack)
            {
                _state = State.attack;
                NextTimeToAttack = Time.time + TimeBetweenAttack;
           
            }
            else
            {
                _state = State.flyaway;
            }
        }
        else if(dis <= followDistance) 
        {
            _state = State.follow;
        }
        else
        {
            _state = State.idle;
        }
        anim.SetInteger("State" , (int) _state);    
        
    }
 
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(colider.bounds.center, followDistance);
    }
}
