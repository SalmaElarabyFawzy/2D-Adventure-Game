using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private PlayerManager player;
    private  SpriteRenderer sprite;
   
    private Animator anim;
    
    private enum MovementState { idle , running ,jumping, falling ,attack , hurt}
   
    public AudioSource Run_Audio;
    public AudioSource jumpSound;
    
    // Start is called before the first frame update
    void Start()
    {
   
        anim =GetComponent<Animator>(); 
        player = GetComponent<PlayerManager>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        updateAnimation();
    }


    void updateAnimation()
    {
        MovementState state ;
        if (player.Dirx>0 && player.checkground())
        {
            state = MovementState.running;
            sprite.flipX = false;
            Run_Audio.enabled = true;
        }
        else if(player.Dirx < 0 && player.checkground())
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
        if(player.Attack)
        {
            state = MovementState.attack;
        }
        if(player.RB.velocity.y>.1f)
        {
            state= MovementState.jumping;
        }
        else if(player.RB.velocity.y<-.1f)
        {
            state= MovementState.falling;
        }

        anim.SetInteger("State", (int)state);
    }

    
   
    
}
