using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioMnagaer : MonoBehaviour
{
    public static GameAudioMnagaer instance;

    public AudioSource[] audios;

    private void Awake()
    {
        /*if(instance==null)
        {
            instance=this;
        }*/
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
        audios = GetComponents<AudioSource>();
        PlayBgMusic();
    }


    public void PlayGameOverMusic()
    {
        audios[1].Play();
    }
    public void PlayDroppedAudio()
    {
        audios[0].Play();
    }
    public void StopBgMusic()
    {
        audios[2].Stop();
    }
    public void PlayBgMusic()
    {
        audios[2].Play();
    }
    public void PlaySwooshAudio()
    {
        audios[3].Play();
    }
    public void PlayGameWinMusic()
    {
        audios[4].Play();
    }
    public void PlayScoreUpMusic()
    {
        audios[5].Play();
    }
    
    
}
