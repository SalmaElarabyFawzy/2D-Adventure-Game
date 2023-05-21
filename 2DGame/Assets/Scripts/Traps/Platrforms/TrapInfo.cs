using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapInfo : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private GameObject[] waypoint;
    private BoxCollider2D boxcollider;
    // Start is called before the first frame update
    void Start()
    {
        boxcollider = GetComponent<BoxCollider2D>();    
    }

    void Update()
    {
        
    }
}
