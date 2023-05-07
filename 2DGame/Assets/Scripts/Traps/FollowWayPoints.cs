using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPoints : MonoBehaviour
{
    [SerializeField] private GameObject[] WayPoints;
    [SerializeField] private float speed;
    private int CurrentWayPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(WayPoints[CurrentWayPoint].transform.position,transform.position)<.1f)
        {
            CurrentWayPoint++;
            if(CurrentWayPoint>=WayPoints.Length)
            {
                CurrentWayPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, WayPoints[CurrentWayPoint].transform.position, speed * Time.deltaTime);
    }
}
