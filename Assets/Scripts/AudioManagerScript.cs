using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{
    public AudioSource[] audios;

    public static AudioManagerScript instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponents<AudioSource>();

        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "Game")
        {
            PlayBgMusic();
            
        }
        else
        {
            print("This is not my scene");
        }

        
    }
    private void Update()
    {
    }

    public void PlayBgMusic()
    {
        audios[0].Play();
    }
    public void StopBgMusic()
    {
        audios[0].Stop();
    }
    

    
}
