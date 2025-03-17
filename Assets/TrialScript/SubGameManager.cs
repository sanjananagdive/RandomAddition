using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubGameManager : MonoBehaviour
{
    public static SubGameManager instance;


    public bool gameOver=false;
    public bool gameRestarted=false;
    public bool gameOverAudioPlayed=false;
    //public GameObject gameOverPanel;

    //public GameObject gameOverPanelPrefab;     
    //private GameObject currentGameOverPanel;   



    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make it persistent
        }
        else
        {
            Destroy(gameObject); // Avoid having multiple instances
        }
    }

    void Update()
    {
        if(gameOver)
        {
            GameOver();
        }

        
        
    }
    
    public void ReloadSceneWithDelay()
    {
        gameOver=false;
        Invoke("ReloadScene",1f);
    }

    private void ReloadScene()
    {

        gameRestarted = true;
        if(gameOver)
        {
            gameOver=false;
        }
        SceneManager.LoadScene("Substraction");
        //ScoreManagerScript.instance.SetGop();

    }
    public void RestartGame()
    {
        gameOver = false;
        gameRestarted = true;
        gameOverAudioPlayed=false;
        SceneManager.LoadScene("Substraction");
        //AudioManagerScript.instance.PlayBgMusic();
        GameAudioMnagaer.instance.PlayBgMusic();
        ScoreManagerScript.instance.ResetScore();
    }
    public void LoadMainMenu()
    {
        gameRestarted=true;
        if(gameOver)
        {
            gameOver=false;
        }
        Destroy(gameObject);
        print("destroyed game manager and score manager");
        ScoreManagerScript.instance.DestroyScoreManager();//

        SceneManager.LoadScene("MainMenu");
        
    }
    
    public void LoadGame()
    {
        gameRestarted=true;
        if(gameOver)
        {
            gameOver=false;
        }
        SceneManager.LoadScene("Substraction");
        
    }
    public void ExitGame()
    {
        print("Application Quit");
        Application.Quit();
    }

    public void GameOver()
    {
       
        gameOver = true;
        //AudioManagerScript.instance.StopBgMusic();
        GameAudioMnagaer.instance.StopBgMusic();

        if(!gameOverAudioPlayed)
        {
            GameAudioMnagaer.instance.PlayGameOverMusic();
            gameOverAudioPlayed=true;
        }
        //AudioManagerScript.instance.PlayGameOverMusic();
    }

}