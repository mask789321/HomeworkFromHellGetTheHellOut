using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.Events;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject VolumePanel;
    [SerializeField] GameObject CreditPanel;
    [SerializeField] GameObject VolumeBackButton;
    [SerializeField] GameObject ControlsBackButton;
    public Slider volumeSlider;
    public GameController gcon;
    bool PauseMenuUp = false;
    public Button defaultButton;

    void Start()
    {
     volumeSlider.value = gcon.audSource.volume;
     volumeSlider.onValueChanged.AddListener(ChangeVolume);

     if (defaultButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);
        }
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    void ChangeVolume(float volume)
    {
        gcon.audSource.volume = volume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseMenuUp)
        {
            Pause();
        }
        }
if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);
        }
        
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        PauseMenuUp = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;

    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        PauseMenuUp = false;
        Time.timeScale = 1;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    public void Credits()
    {
       // PauseMenuUp = true;
        CreditPanel.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void Volume()
    {
        //PauseMenuUp = true;
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
        //PauseMenuUp = false;
        VolumePanel.SetActive(false);
        PausePanel.SetActive(true);
    }

    public void ReturnCredit()
    {
        //PauseMenuUp = false;
        CreditPanel.SetActive(false);
        PausePanel.SetActive(true);
    }
}
