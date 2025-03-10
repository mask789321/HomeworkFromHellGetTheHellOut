/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemypath : MonoBehaviour
{
    public GameController gameCon;
    public Transform[] waypoints; // Assign in Inspector
    public float speed = 2f;
    private int currentWaypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length == 0) return;

        // Move toward the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        // Check if we reached the waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Loop back
        }
    }

}
*/
//this script was conflicting with another script of the same name