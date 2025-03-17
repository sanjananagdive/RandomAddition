using UnityEngine;
using UnityEngine.UI;

public class PersistentButtonManager : MonoBehaviour
{
    public Button addButton;
    public Button subsButton;
    public Button mulButton;
    public Button divButton;

    public bool resetScore=false;

    public static PersistentButtonManager instance;

    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        // Clear existing listeners to avoid duplicating events if the scene reloads
        addButton.onClick.RemoveAllListeners();
        subsButton.onClick.RemoveAllListeners();
        mulButton.onClick.RemoveAllListeners();
        divButton.onClick.RemoveAllListeners();

        // Assign the button click events
        addButton.onClick.AddListener(OnButton1Click);
        subsButton.onClick.AddListener(OnButton2Click);
        mulButton.onClick.AddListener(OnButton3Click);
        divButton.onClick.AddListener(OnButton4Click);
    }

    void OnButton1Click()
    {
        Debug.Log("Add button was clicked!");
        GameManagerScript.instance.LoadAdditionGame();
        //resetScore = true;
        // Add specific actions for button1
    }
    void OnButton2Click()
    {
        Debug.Log("Subs button was clicked!");
        GameManagerScript.instance.LoadSubstractionGame();
        // Add specific actions for button1
    }

    void OnButton3Click()
    {
        Debug.Log("Mul button was clicked!");
        GameManagerScript.instance.LoadMultiplicationGame();
        // Add specific actions for button2
    }
    void OnButton4Click()
    {
        Debug.Log("Div button was clicked!");
        GameManagerScript.instance.LoadDivisionGame();
        // Add specific actions for button2
    }
}
