using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private EnemyManager manager;
    private AnimationContrlle animation;
    private SimpleAiManager ai;


    private void Start()
    {
        manager = GetComponent<EnemyManager>();
        animation= GetComponent<AnimationContrlle>();
        ai = GetComponent<SimpleAiManager>();
    }




    public void GetHurt(float strength)
    {
        manager.Health -= strength;
        if(manager.Health <= .1f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
