using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerManager player;
    private Rigidbody2D Rb;
    private float speed;
    private float dirx;
    private bool attack;
    private float jumpHeight;
    private BoxCollider2D boxcolid;
    private LayerMask ground;


    public bool Attack
    {
        get { return attack; }
    }
    public float Dirx
    {
        get { return dirx; }
    }
     

    void Awake()
    {
        player = GetComponent<PlayerManager>();
        Rb = player.RB;
        speed = player.Speed;
        jumpHeight= player.JumpHeight;
        boxcolid = player.Boxcolid;
        ground = player.Ground;
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
}
