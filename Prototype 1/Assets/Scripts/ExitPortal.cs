using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        PlayerController controller = collision.collider.GetComponent<PlayerController>();
        //Debug.Log("Enemy Hit Sum'");

        if (controller != null)
        {
    
        SceneManager.LoadScene("Gameplay Prototype");
        Debug.Log("Hit It");
    }
        }
    }
            //Debug.Log("Ouch");

    
