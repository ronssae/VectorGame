using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    [SerializeField] private float speed;
    private int targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == wayPoints[targetPoint].position)
        {
            ChangeWayPoint();
        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[targetPoint].position, speed * Time.deltaTime);
    }
    
    void ChangeWayPoint()
    {
        targetPoint++;
        if (targetPoint >= wayPoints.Length)
        {
            targetPoint = 0;
        }
    }
}
