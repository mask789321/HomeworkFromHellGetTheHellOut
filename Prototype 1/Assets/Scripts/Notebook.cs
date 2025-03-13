using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    public GameController gcon;
    public GameObject portal;
    public AudioClip collected;
    public AudioClip RushMusic;
    public GameObject Demons;
    //public AudioSource audSource;
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
            gcon.audSource.PlayOneShot(collected);
            portal.SetActive(true);
            gcon.audSource.Stop();
           gcon.audSource.clip = RushMusic;
            gcon.audSource.Play();
            Demons.SetActive(true);
            Destroy(this);
            Destroy(gameObject);
            //Debug.Log("Ouch");
        }
    }
}
