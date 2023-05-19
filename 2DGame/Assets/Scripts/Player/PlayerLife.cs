using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D player;
    [SerializeField] private float HP = 100;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
      
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
        HP -= strenght;
        if(HP<=.1f)
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
