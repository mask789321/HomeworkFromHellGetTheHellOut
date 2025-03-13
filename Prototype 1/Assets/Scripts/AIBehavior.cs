using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AIBehavior : MonoBehaviour
{
    //public GameObject patrolPathObj;
    private NavMeshAgent nav;
    private Vector2 moveInput;
    
    private Transform player;
    public float enemySight = 5;
    private int CurrentWaypoint;
    private PatrolPath path;
    float timeAtWaypoint = 0;
    [SerializeField] float RequiredWaypointTime = 5f;
    private float timeSinceDetected = 4;
    private bool chaseState = false;
    public GameController gcon;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.transform;
        GameObject patrolPathObj = GameObject.FindWithTag("Waypoints");
        path = patrolPathObj.GetComponent<PatrolPath>();
    }


    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < enemySight)
        {
            timeSinceDetected = 0;
            chaseState = true;
            //Debug.Log("Player Detected");
            MoveTo(player.position);
        } else if (timeSinceDetected < 3)
        {
            timeSinceDetected += Time.deltaTime;
            chaseState = false;
            nav.isStopped = true;
        } else 
        {
            Patrol();
            //Debug.Log("Patrolling");
        }

        
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
            gcon.damage();
            Debug.Log("Enemy Attacks Player");
        }
    }

            private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, enemySight);
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

