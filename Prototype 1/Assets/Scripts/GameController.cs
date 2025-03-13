using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    public AudioClip MainGameMusic;
    public AudioClip WinMusic;
    public AudioSource audSource;
    public int penNum = 0;
    private int enemyNum = 0;
    public GameObject guard;
    public GameObject finalPenl;
    public Transform PenspawnPoint;
    public Transform spawnPoint;
    bool WinState = false;
    public int health = 2;
    public GameObject GameOverMenu;

    public GameObject vignetteLayer;
    public bool isMainMenu = false;


    // Start is called before the first frame update
    void Start()
    {
        
        if ( isMainMenu)
        {
            Debug.Log("yes");
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        }
        audSource = GetComponent<AudioSource>();
        //audSource.PlayOneShot(MainGameMusic);
        audSource.clip = MainGameMusic;
        audSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (penNum == 1 && enemyNum == 0)
        {
            Instantiate(guard, spawnPoint.position, spawnPoint.rotation);
            
            enemyNum++;
        }
        
        if (penNum >= 6 && WinState == false)
        {
            WinState = true;
            //audSource.Stop();
            //audSource.PlayOneShot(WinMusic);
            finalPenl.SetActive(true);
            //Instantiate(finalPenl, PenspawnPoint.position, PenspawnPoint.rotation);
            //Debug.Log("You Win");
        }
    }

    public void damage()
    {
        health--;
        if (health <= 1)
        {
            vignetteLayer.SetActive(true);
        }
            if (health == 0)
            {
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                UnityEngine.Cursor.visible = true;
                Time.timeScale = 0;
                GameOverMenu.SetActive(true);
                Debug.Log("Player Dead");
            }
            Debug.Log("Enemy Attacks Player");
    }


}
