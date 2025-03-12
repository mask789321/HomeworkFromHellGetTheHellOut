using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    private Vector2 moveInput;
    private float currentSpeed = 0f;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 15f;
    
    

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        //nav.speed = _speed;
        nav.updateRotation = false; // Prevents automatic rotation
        nav.updateUpAxis = false; // Keeps player upright if needed
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

        // If there's movement, set the agent's velocity
        if (moveDirection.magnitude > 0.1f)
        {
            Vector3 targetPosition = transform.position + moveDirection;
            nav.SetDestination(targetPosition);
            //nav.velocity = moveDirection * nav.speed;
        }
        else
        {
            nav.ResetPath();
            //nav.velocity = Vector3.zero;
        }*/


        Vector3 moveDirection = Vector3.zero;

        if (moveInput.sqrMagnitude > 0.01f) // If there's movement input
        {
            Vector3 forward = Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;
            Vector3 right = Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;
            moveDirection = (forward * moveInput.y + right * moveInput.x).normalized;

            // Gradually increase speed up to maxSpeed
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            // Gradually slow down when input is released
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
        }

        // Move manually and sync with NavMeshAgent
        Vector3 targetPosition = transform.position + moveDirection * currentSpeed * Time.deltaTime;
        nav.nextPosition = targetPosition;
        transform.position = targetPosition;

        // Rotate smoothly towards movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
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

    

