using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    /// <summary>
    /// Lets the player retry the game
    /// </summary>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// lets the player quit the game
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("You quit the game.");
        Application.Quit();
    }
}
