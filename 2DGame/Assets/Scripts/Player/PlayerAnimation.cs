using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private PlayerManager player;
    private Animator anim;
    private PlayerInput input;
    private bool attack;
    private bool checkground;
    private float Dirx;
    private enum MovementState { idle , running ,jumping, falling ,attack , hurt}
   
    
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<PlayerManager>();
        input = GetComponent<PlayerInput>();
        anim = player.Animator;
        attack = input.Attack;
        checkground = input.checkground();
        Dirx = input.Dirx;
    }

    // Update is called once per frame
    void Update()
    {
        updateAnimation();
    }


    void updateAnimation()
    {
        MovementState state ;
        if (Dirx>0 && checkground)
        {
            state = MovementState.running;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            player.Run_Audio.enabled = true;
        }
        else if(Dirx < 0 && checkground)
        {
            state = MovementState.running;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            player.Run_Audio.enabled = true;
        }
        else
        {
            state = MovementState.idle;
           player.Run_Audio.enabled = false;
        }
        if(attack)
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
