using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    private Vector2 moveInput;


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

        // If there's movement, set the agent's velocity
        if (moveDirection.magnitude > 0.1f)
        {
            nav.velocity = moveDirection * nav.speed;
        }
        else
        {
            nav.velocity = Vector3.zero;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); // Read joystick input
        //Debug.Log("Up was pressed:");
    }

 

    public void Up1(InputAction.CallbackContext context)
    {
        //moveInput = context.ReadValue<Vector2>(); // Read joystick input
        //Debug.Log("Up was pressed:");
    }
}

    

