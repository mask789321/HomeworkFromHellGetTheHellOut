using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidewaypoints : MonoBehaviour
{
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<renderer>().enabled = false;
    }
}
