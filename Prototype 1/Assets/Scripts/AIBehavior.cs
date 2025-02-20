using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AIBehavior : MonoBehaviour
{
    private NavMeshAgent nav;
    private Vector2 moveInput;
    
    private Transform player;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.transform;
    }


    // Update is called once per frame
    void Update()
    {
        MoveTo(player.position);
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
}

