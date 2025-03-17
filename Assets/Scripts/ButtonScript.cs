using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public AudioSource audioSource; // Reference to AudioSource component

    void Start()
    {
        // Attach this script to the button and add onClick listener
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        audioSource.Play(); // Play sound when button is clicked
    }
}
