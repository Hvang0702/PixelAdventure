using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    
    [SerializeField] private GameObject[] waypoints; //to initialize multiple waypoints at same time 
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
   
    private void Update()
    {
        //if the current waypoint and platform are at a distance then we switch to next waypoint
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length) //this checks to see if we are at the last waypoint
            {
                currentWaypointIndex = 0; //set back to 0

            }
        }
        //to move back and forth the platform
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    





}
