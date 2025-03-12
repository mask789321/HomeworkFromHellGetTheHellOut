using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameController gcon;
    public AudioClip WinMusic;
    public GameObject GameWinScreen;
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
        //SceneManager.LoadScene("Gameplay Prototype");
        GameWinScreen.SetActive(true);
        Time.timeScale = 0;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        gcon.audSource.Stop();
        gcon.audSource.clip = WinMusic;
        gcon.audSource.Play();
        Debug.Log("Win");
    }
        }
    }
            //Debug.Log("Ouch");

    
