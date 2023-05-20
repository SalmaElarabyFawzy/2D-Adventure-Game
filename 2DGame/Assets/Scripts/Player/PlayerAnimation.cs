using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private PlayerManager player;
   
   
    private Animator anim;
    
    private enum MovementState { idle , running ,jumping, falling ,attack , hurt}
   
    
    
    // Start is called before the first frame update
    void Start()
    {
   
        anim =GetComponent<Animator>(); 
        player = GetComponent<PlayerManager>();
    
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
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            player.Run_Audio.enabled = true;
        }
        else if(player.Dirx < 0 && player.checkground())
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
