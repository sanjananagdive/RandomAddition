using UnityEngine;

public class GameDifficultyManager : MonoBehaviour
{
    public static GameDifficultyManager instance;
    public int winThreshold;  // The score required to win

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep it across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy":
                winThreshold = 50;
                break;
            case "Medium":
                winThreshold = 100;
                break;
            case "Hard":
                winThreshold = 200;
                break;
            default:
                winThreshold = 100; // Default to Medium
                break;
        }

        PlayerPrefs.SetInt("WinThreshold", winThreshold);  // Save the setting
        PlayerPrefs.Save();
    }
    public int GetDifficultyThreshold()
    {
        return PlayerPrefs.GetInt("WinThreshold", 100);  // Default to Medium
    }

}
