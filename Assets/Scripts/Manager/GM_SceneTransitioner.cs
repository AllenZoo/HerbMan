using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_SceneTransitioner : MonoBehaviour
{

    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
