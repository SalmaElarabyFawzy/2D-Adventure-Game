using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   
    [SerializeField] private Transform player;
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;


    [SerializeField]
    private float camWidth, camHight;
    private float LeftBound , RightBound ;  

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camHight = Camera.main.orthographicSize * 2;
        camWidth = camHight / Camera.main.aspect;
        LeftBound = leftBound.position.x + (camWidth/2);
        RightBound = rightBound.position.x - (camWidth / 2);
    }
    void Update()
    {
       
        float pos = Mathf.Max(LeftBound , Mathf.Min(player.position.x , RightBound));
        transform.position = new Vector3(pos , (player.position.y/3) , transform.position.z);
    }
}
