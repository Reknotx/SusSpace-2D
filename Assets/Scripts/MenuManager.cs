using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    /**
     * <summary>Loads next scene of the game.</summary>
     */
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /**
     * <summary>Restarts the current level.</summary>
     */
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void CloseGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;

        #else
                 Application.Quit();
        #endif

    }
}
