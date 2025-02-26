using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject VolumePanel;
    [SerializeField] GameObject CreditPanel;
    [SerializeField] GameObject VolumeBackButton;
    [SerializeField] GameObject ControlsBackButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;



    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    public void Credits()
    {
        CreditPanel.SetActive(true);
    }

    public void Volume()
    {
        VolumePanel.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void ReturnVolume()
    {
        VolumePanel.SetActive(false);
        PausePanel.SetActive(true);
    }

    public void ReturnCredit()
    {
        CreditPanel.SetActive(false);
        PausePanel.SetActive(true);
    }
}
