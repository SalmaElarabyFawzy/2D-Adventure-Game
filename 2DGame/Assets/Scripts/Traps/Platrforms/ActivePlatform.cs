using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlatform : MonoBehaviour
{
    [SerializeField] private GameObject ActivePoint;
    [SerializeField] private Transform EndPoint;
    private BoxCollider2D colider;
    [SerializeField] private float Speed;
    private bool move = false;
    void Start()
    {
        colider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if(!ActivePoint.active)
        {
            colider.enabled = true;
        }
        if(move && transform.position != EndPoint.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, EndPoint.transform.position, Speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag==("Player"))
        {
            move = true;
        }
    }
}
