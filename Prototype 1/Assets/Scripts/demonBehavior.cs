using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class demonBehavior : MonoBehaviour
{
    private NavMeshAgent nav;
    private Vector2 moveInput;
    
    private Transform player;
    private int CurrentWaypoint;
    private PatrolPath path;
    float timeAtWaypoint = 0;
    [SerializeField] float RequiredWaypointTime = 5f;
    public GameObject patrolPathObj;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.transform;
        //GameObject patrolPathObj = GameObject.FindWithTag("Waypoints");
        path = patrolPathObj.GetComponent<PatrolPath>();
    }


    // Update is called once per frame
    void Update()
    {
        Patrol();        
    }

    public void MoveTo(Vector3 destination)
    {
        GetComponent<NavMeshAgent>().destination = destination;
        nav.isStopped = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerController controller = collision.collider.GetComponent<PlayerController>();
        //Debug.Log("Enemy Hit Sum'");

        if (controller != null)
        {
            Debug.Log("Enemy Attacks Player");
        }
    }

    void Patrol()
    {
        MoveTo(path.GetWaypoint(CurrentWaypoint));
        if (AtWaypoint())
        {
            timeAtWaypoint += Time.deltaTime;
                    if (timeAtWaypoint >= RequiredWaypointTime)
                    {
                        CycleWaypoint();
                        timeAtWaypoint = 0f;
                    }

            //CycleWaypoint();
        }
    }

        private void CycleWaypoint()
        {
            CurrentWaypoint = path.GetNextIndex(CurrentWaypoint);
        }

        private bool AtWaypoint()
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, path.GetWaypoint(CurrentWaypoint));
            return distanceToWaypoint < .1f;
        }
}
