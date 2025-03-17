using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManagerScript : MonoBehaviour
{
    public static ScoreManagerScript instance;

    public static int score = 1;
    private int incrementScoreBy = 10;
    private int decrementScoreBy = 5;

    private int highScore=0;

    private bool decrementWasCalled=false;
    private bool incrementWasCalled=false;

    private int gameWinThreshold = 50; // Default to easy

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI highScoreTxt;

    public GameObject floatingTextPrefab;
    public Transform scoreUpgradePos;
    public GameObject gop;

    void Awake()
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
        // Get the threshold from PlayerPrefs (set by GameDifficultyManager)
        int threshold = GameDifficultyManager.instance.GetDifficultyThreshold();
    }

    private void Update()
    {
        /*if(DropSlot.instance.correctlyPlaced)
        {
            IncrementScore();
        }*/

    

        if(score<=0)
        {
            print("Gamover");
            GameManagerScript.instance.gameOver = true;
            
        }
        else if(score>=GameDifficultyManager.instance.GetDifficultyThreshold())
        {
            print("GAME WIN!");
            GameManagerScript.instance.gameWin = true;

        }
        else
        {
            GameManagerScript.instance.gameOver = false;
        }

        /*if(score<=0)
        {
            if( score!=0 || (score==0  && (ScoreIncremented() || ScoreDecremented())))
            {

                if(!GameManagerScript.instance.gameRestarted)
                {
                    print("Game Over!!!");
                    GameManagerScript.instance.gameOver=true;
                    //gop.SetActive(true);
                }
                else
                {
                    GameManagerScript.instance.gameOver=false;
                }
                

            }
            
        }*/

        /*if(score<0)
        {
            GameManagerScript.instance.gameOver = true;
        }*/

        //UpdateHighScore();
        
    }


    public void SetGop()
    {
        gop.SetActive(false);
    }

    bool ScoreDecremented()
    {
        bool go = GameManagerScript.instance.gameOver;
        if(decrementWasCalled && !go)
        {
            return true;
        }
        return false;
    }
    bool ScoreIncremented()
    {
        bool go = GameManagerScript.instance.gameOver;
        if(incrementWasCalled && !go)
        {
            return true;
        }
        return false;
    }
    public void FindScoreText()
    {
        scoreTxt = GameObject.Find("ScoreTxt").GetComponent<TextMeshProUGUI>();
        UpdateScore();
    }

    public void IncrementScore()
    {
        score += incrementScoreBy;
        print("Score =" + score);
        //DropSlot.instance.correctlyPlaced=false;
        UpdateScore();
        ShowFloatingText("+" + incrementScoreBy, Color.white);
        GameAudioMnagaer.instance.PlayScoreUpMusic();

        //incrementWasCalled=true;

        //ResetFlags();

    }

    public void DecrementScore()
    {
        score -= decrementScoreBy;
        UpdateScore();
        ShowFloatingText("-" + decrementScoreBy, new Color(1f, 0.4f, 0.4f)); 
        decrementWasCalled=true;

        ResetFlags();
    }

    private void ShowFloatingText(string text, Color textColor)
    {
        if (floatingTextPrefab == null || scoreUpgradePos == null) return;

        // Instantiate at scoreUpgradePos's position
        GameObject floatingText = Instantiate(floatingTextPrefab, scoreUpgradePos.position, Quaternion.identity, scoreUpgradePos);

        // Set text and color
        TextMeshProUGUI tmp = floatingText.GetComponent<TextMeshProUGUI>();
        tmp.text = text;
        tmp.color = textColor; // Set color dynamically

        // Destroy after animation
        Destroy(floatingText, 1f);
    }




    public void UpdateScore()
    {
        scoreTxt.text = score.ToString();
    }
    /*public void UpdateHighScore()
    {
        if(score>highScore)
        {
            highScore=score;
            print("high score : " + highScore);
            highScoreTxt.text = highScore.ToString();

        }
    }*/
    public void ResetScore()
    {
        score = 1;
        UpdateScore();
    }

    private void ResetFlags()
    {
        incrementWasCalled = false;
        decrementWasCalled = false;
    }
    public void DestroyScoreManager()
    {
        Destroy(gameObject);
    }
}
