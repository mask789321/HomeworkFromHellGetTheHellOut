using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // Start is called before the first frame update
    void Start()
    {
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
}
