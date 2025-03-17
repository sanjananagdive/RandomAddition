using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    //public AudioSource audio;

    public bool add;
    public bool mul;
    public bool subs;
    public bool div;


    public bool gameOver=false;
    public bool gameRestarted=false;
    public bool gameOverAudioPlayed=false;

    public bool gameWin= false;//
    public bool gameWinAudioPlayed=false;//
    //public GameObject gameOverPanel;

    //public GameObject gameOverPanelPrefab;     //
    //private GameObject currentGameOverPanel;   //

    

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
    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(gameOver)
        {
            GameOver();
        }
        if(gameWin)
        {
            GameWin();
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
        if(add && !mul && !subs && !div)
        {
            SceneManager.LoadScene("Addition");
        }
        else if(mul && !add && !subs && !div)
        {
            SceneManager.LoadScene("Multiplication");
        }
        else if(subs && !add && !mul && !div)
        {
            SceneManager.LoadScene("Substraction");
        }
        else if(div && !add && !mul && !subs)
        {
            SceneManager.LoadScene("Division");
        }
        //SceneManager.LoadScene("Game2");
        //ScoreManagerScript.instance.SetGop();

    }
    /*public void RestartGame()
    {
        gameOver = false;
        gameRestarted = true;
        gameOverAudioPlayed=false;
        SceneManager.LoadScene("Game2");
        //AudioManagerScript.instance.PlayBgMusic();
        GameAudioMnagaer.instance.PlayBgMusic();
        ScoreManagerScript.instance.ResetScore();
    }*/

    public void RestartGame()
    {
        gameOver = false;
        gameRestarted = true;
        gameOverAudioPlayed = false;

        string currentScene = SceneManager.GetActiveScene().name;

        // Check which scene you're in and reload it
        if (currentScene == "Addition")
        {
            SceneManager.LoadScene("Addition");
        }
        else if (currentScene == "Substraction")
        {
            SceneManager.LoadScene("Substraction");
        }
        else if (currentScene == "Multiplication")
        {
            SceneManager.LoadScene("Multiplication");
        }
        else if (currentScene == "Division")
        {
            SceneManager.LoadScene("Division");
        }

        // Play background music or reset as necessary
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
        SceneManager.LoadScene("Game2");
        
    }
    public void ExitGame()
    {
        //audio.Play();
        print("Application Quit");
        Application.Quit();
    }
    public void LoadIntroScene()
    {
        SceneManager.LoadScene("IntroScene");
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

    public void GameWin()//
    {
       
        gameWin = true;
        //AudioManagerScript.instance.StopBgMusic();
        GameAudioMnagaer.instance.StopBgMusic();
        
        if(!gameWinAudioPlayed)
        {
            GameAudioMnagaer.instance.PlayGameWinMusic();
            gameWinAudioPlayed=true;
        }
        //AudioManagerScript.instance.PlayGameOverMusic();
    }

    public void LoadAdditionGame()
    {
        //audio.Play();
        //ScoreManagerScript.instance.ResetScore();
        gameRestarted=true;
        gameWin=false;
        if(gameOver)
        {
            gameOver=false;
        }
        SceneManager.LoadScene("Addition");

        add = true;
        subs = false;
        mul = false;
        div = false;

        //EqgeneratorScript.instance.add = true;
        //EqgeneratorScript.instance.subs = false;
        //EqgeneratorScript.instance.div = false;
       // EqgeneratorScript.instance.mul = false;

        
    }
    public void LoadDivisionGame()
    {
        ScoreManagerScript.instance.ResetScore();
        gameWin=false;
        gameWinAudioPlayed=false;
        GameAudioMnagaer.instance.PlayBgMusic();
        
        //audio.Play();
        gameRestarted=true;
        gameWin=false;
        if(gameOver)
        {
            gameOver=false;
        }
        SceneManager.LoadScene("Division");
        GameAudioMnagaer.instance.PlayBgMusic();

        div = true;
        subs = false;
        mul = false;
        add = false;

       // EqgeneratorScript.instance.div = true;
       // EqgeneratorScript.instance.subs = false;
       // EqgeneratorScript.instance.div = false;
       // EqgeneratorScript.instance.add = false;
        
    }
    public void LoadSubstractionGame()
    {
        //audio.Play();
        ScoreManagerScript.instance.ResetScore();
        gameWin=false;
        gameWinAudioPlayed=false;
        GameAudioMnagaer.instance.PlayBgMusic();

        gameRestarted=true;
        gameWin=false;
        if(gameOver)
        {
            gameOver=false;
        }
        SceneManager.LoadScene("Substraction");
        GameAudioMnagaer.instance.PlayBgMusic();

        subs = true;
        add = false;
        mul = false;
        div = false;

        

        //EqgeneratorScript.instance.subs = true;
        //EqgeneratorScript.instance.add = false;
        //EqgeneratorScript.instance.div = false;
        //EqgeneratorScript.instance.mul = false;
        
    }
    public void LoadMultiplicationGame()
    {
        ScoreManagerScript.instance.ResetScore();
        gameWin=false;
        gameWinAudioPlayed=false;
        GameAudioMnagaer.instance.PlayBgMusic();
        //audio.Play();
        gameRestarted=true;
        gameWin=false;
        if(gameOver)
        {
            gameOver=false;
        }
        SceneManager.LoadScene("Multiplication");
        GameAudioMnagaer.instance.PlayBgMusic();

        mul = true;
        subs = false;
        add = false;
        div = false;

        //EqgeneratorScript.instance.mul = true;
        //EqgeneratorScript.instance.subs = false;
        //EqgeneratorScript.instance.div = false;
        //EqgeneratorScript.instance.add = false;
        
    }
    public void ReturnToMenu()
    {
        //audio.Play();
        LoadMenuScene();
        ScoreManagerScript.instance.DestroyScoreManager();
    }
    public void LoadMenuScene()
    {
        //audio.Play();
        SceneManager.LoadScene("MenuScene");
    }
    public void LoadNextScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        if (currentSceneName == "Addition")
        {
           LoadSubstractionGame();
        }
        if (currentSceneName == "Substraction")
        {
           LoadMultiplicationGame();
        }
        if (currentSceneName == "Multiplication")
        {
           LoadDivisionGame();
        }
        if (currentSceneName == "Division")
        {
           SceneManager.LoadScene("IntroScene");
        }

    }

    public void SelectEasyMode()
    {
        GameDifficultyManager.instance.SetDifficulty("Easy");
    }

    public void SelectMediumMode()
    {
        GameDifficultyManager.instance.SetDifficulty("Medium");
    }

    public void SelectHardMode()
    {
        GameDifficultyManager.instance.SetDifficulty("Hard");
    }
    /*public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            ScoreManagerScript.instance.ResetScore();
            gameWin=false;
            gameWinAudioPlayed=false;
            GameAudioMnagaer.instance.PlayBgMusic();
        }
        else
        {
            Debug.Log("No more scenes to load!");
        }

    }*/
    

    

}
