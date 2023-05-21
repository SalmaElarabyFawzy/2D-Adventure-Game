using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D player;
    private PlayerManager manager;



    void Start()
    {
        manager = GetComponent<PlayerManager>();
        anim = manager.Animator;
        player = manager.RB;
    }
   



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Traps"))
        {
            collision.collider.enabled= false;
            Die();
        }
    }


    public void GetHurt(float strenght)
    {
        manager.HP -= strenght;
        if(manager.HP<=.1f)
        {
            Die();
        }
    }
    private void Die()
    {
        anim.SetTrigger("Death");
        player.bodyType = RigidbodyType2D.Static;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  
}
