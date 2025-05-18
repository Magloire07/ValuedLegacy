using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource backgroundMusic;
    public AudioSource alertMusic;
    public AudioSource gameOverMusic;

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

    public void PlayAlertMusic()
    {
        if (!alertMusic.isPlaying)
            alertMusic.Play();
    }

    public void StopAlertMusic()
    {
        if (alertMusic.isPlaying)
            alertMusic.Stop();
    }

    public void PlayGameOverMusic()
    {
        if (!gameOverMusic.isPlaying)
            gameOverMusic.Stop();
    }

    public void StopGameOverMusic()
    {
        if (gameOverMusic.isPlaying)
            gameOverMusic.Stop();
    }
}