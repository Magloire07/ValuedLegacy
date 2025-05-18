using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerSpaceship : MonoBehaviour
{
    public static MusicManagerSpaceship instance;

    public AudioSource backgroundMusic;
    public AudioSource typingMusic;
    public AudioSource overMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (!backgroundMusic.isPlaying)
            backgroundMusic.Play();
    }

    public void PlayTypingMusic()
    {
        if (!typingMusic.isPlaying)
            typingMusic.Play();
    }

    public void StopTypingMusic()
    {
        if (typingMusic.isPlaying)
            typingMusic.Stop();
    }

    public void PlayOverMusic()
    {
        if (!overMusic.isPlaying)
            overMusic.Play();
    }

    public void StopOverMusic()
    {
        if (overMusic.isPlaying)
            overMusic.Stop();
    }

}

