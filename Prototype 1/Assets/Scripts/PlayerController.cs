using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Gamepad.current != null)
    {
        Debug.Log("Gamepad is connected: " + Gamepad.current.name);
    }
    else
    {
        Debug.Log("No gamepad connected.");
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
