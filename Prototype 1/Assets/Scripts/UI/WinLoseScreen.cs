using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject GameWinScreen;
    [SerializeField] GameObject CreditPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            test();
            CreditPanel.SetActive(false);
        }
    }

    void test()
    {
        GameWinScreen.SetActive(true);
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

}
