using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;

    int currentWaypointIndex = 0;

    [SerializeField] float speed = 2f;
    
    // Makes moving platform move towards the set waypoints
    void Update() {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f) {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, 
                                waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);    
    }
}
