using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// loads the game scene
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// lets the player quit the game
    /// </summary>
    public void Quit()
    {
        Debug.Log("You quit the game.");
        Application.Quit();
    }

}
