using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D Rb;
    private  SpriteRenderer sprite;
    public float speed;
    public float jumpHeight;
    private float dirx =0;
    private Animator anim;
    private  BoxCollider2D boxcolid;
    public LayerMask ground;
    public AudioSource Run_Audio;
    private enum MovementState { idle , running ,jumping, falling ,attack , hurt}
   
    public AudioSource jumpSound;
    [SerializeField] private float HP;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>(); 
        anim =GetComponent<Animator>(); 
        boxcolid = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         dirx = Input.GetAxis("Horizontal");
       
        
         Rb.velocity = new Vector2(dirx *speed, Rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && checkground())
        {
            Rb.velocity = new Vector2(Rb.velocity.x, jumpHeight);
        }
        
        updateAnimation();
  
    }


    void updateAnimation()
    {
        MovementState state ;
        if (dirx>0 && checkground())
        {
            state = MovementState.running;
            sprite.flipX = false;
            Run_Audio.enabled = true;
        }
        else if(dirx<0 && checkground())
        {
            state = MovementState.running;
            sprite.flipX = true;
            Run_Audio.enabled = true;
        }
        else
        {
            state = MovementState.idle;
            Run_Audio.enabled = false;
        }

        if(Rb.velocity.y>.1f)
        {
            state= MovementState.jumping;
        }
        else if(Rb.velocity.y<-.1f)
        {
            state= MovementState.falling;
        }

        anim.SetInteger("State", (int)state);
    }

    bool checkground()
    {
        return Physics2D.BoxCast(boxcolid.bounds.center, boxcolid.bounds.size, 0, Vector2.down, .1f, ground);
    }
   
    
}
