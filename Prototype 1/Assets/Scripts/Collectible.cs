using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject doorObject;
    public AudioClip collected;
    public GameController gcon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerController controller = collision.collider.GetComponent<PlayerController>();
        //Debug.Log("Enemy Hit Sum'");

        if (controller != null)
        {
            gcon.audSource.PlayOneShot(collected);
            gcon.penNum++;
            Destroy(doorObject);
            Destroy(gameObject);
            //Debug.Log("Ouch");
        }
    }
}
