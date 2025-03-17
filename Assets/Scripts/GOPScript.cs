using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GOPScript : MonoBehaviour
{

    public static GOPScript instance;
    private GameManagerScript gameManager;

    public Button reloadButton;
    

    private void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
    }
    // Assuming this script is attached to the parent GameObject

    void ActivateChildByIndex()
    {
        // Activate the first child (index 0)
        transform.GetChild(0).gameObject.SetActive(true);
    }

    void DeactivateChildByIndex()
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
        if (reloadButton != null)
        {
            reloadButton.onClick.AddListener(() => gameManager.RestartGame());
        }
    }

    void Update()
    {
        if (gameManager.gameOver)
        {
            ActivateChildByIndex();
        }
        else
        {
            DeactivateChildByIndex();
        }
    }
    
    
    

}
