using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        // Reset game state
        GameManagerScript.instance.gameOver = false; // Ensure gameOver flag is reset

        /*GameObject gop = GameManagerScript.instance.gameOverPanel;

        if (gop != null)
        {
            gop.SetActive(false); // Hide the GameOver panel
        }*/
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void AdditionGame()
    {
        SceneManager.LoadScene("Addition");

        
    }
}
