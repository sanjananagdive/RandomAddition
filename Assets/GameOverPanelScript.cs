using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelScript : MonoBehaviour
{
    public Button restartButton; // Drag and drop your restart button in the Inspector

    void Start()
    {
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(ReloadCurrentScene);
        }
        else
        {
            Debug.LogWarning("Restart Button is not assigned in GameWinPanelScript!");
        }
    }

    void ReloadCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        print("loaded scene");
    }
}
       
