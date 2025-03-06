using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTransition : MonoBehaviour
{

    public void LoadScene()
    {
        SceneManager.LoadScene("Gameplay Prototype");
        Debug.Log("Next Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game ended.");

    }
}
