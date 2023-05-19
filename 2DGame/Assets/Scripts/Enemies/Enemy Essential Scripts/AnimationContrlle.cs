using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContrlle : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private string[] animationNames;
    private Animator anim;
    private string currentState;
    private string nextState;
    public Animator Anim
    {
        get { return anim; }
        set { anim = value; }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public string AnimationNames(int index)
    {
      
        return animationNames[index];
    }
}
