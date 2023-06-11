using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;


   public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; //we want to freeze the game
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    public void SceneLoader()
    {
        SceneManager.LoadScene("Level 2");
    }

}
