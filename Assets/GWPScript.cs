using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GWPScript : MonoBehaviour
{

    private GameManagerScript gameManager;

    public Button nextButton;
    

    
    // Assuming this script is attached to the parent GameObject

    private void ActivateChildByIndex()
    {
        // Activate the first child (index 0)
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void DeactivateChildByIndex()
    {
        // Deactivate the first child (index 0)
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void Start()
    {
        // Find the GameManager in the scene when the panel is reloaded
        gameManager = FindObjectOfType<GameManagerScript>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }

        // Dynamically assign the reload button to the GameManager's Reload method
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(() => gameManager.LoadNextScene());
        }
    }

    void Update()
    {
        if (gameManager.gameWin)
        {
            ActivateChildByIndex();
        }
        else
        {
            DeactivateChildByIndex();
        }
    }
     

}
