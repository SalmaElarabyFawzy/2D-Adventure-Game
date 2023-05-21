using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlatform2 : MonoBehaviour
{
    [SerializeField] private GameObject ActivePoint;
    [SerializeField] private Transform EndPoint;
    [SerializeField] private float Speed;
    private BoxCollider2D colider;
    private bool move = false;


    void Start()
    {
        colider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
       
        if (move && transform.position != EndPoint.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, EndPoint.transform.position, Speed * Time.deltaTime);
        }
        if(transform.position == EndPoint.position)
        {
           StartCoroutine( DisableCollider());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == ("Player"))
        {
            move = true;
        }
    }
    private IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(2f);
        colider.enabled = false;
    }

}
