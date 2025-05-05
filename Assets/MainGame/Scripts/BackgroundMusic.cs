using System.Collections;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public float targetVolume = 1f;  // Final volume level
    public float fadeDuration = 30.0f;  // Duration of fade-in

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on this GameObject!");
            return;
        }

        audioSource.volume = 0f; // Start at low volume
        audioSource.Play();
        StartCoroutine(FadeInMusic());
    }

    private IEnumerator FadeInMusic()
    {
        float elapsedTime = 0f;
        float startVolume = 0f;

        //Debug.Log("Starting volume fade-in...");

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / fadeDuration);
            //Debug.Log("Volume: " + audioSource.volume);
            yield return null;
        }

        audioSource.volume = targetVolume;  // Ensure it reaches final volume
       //Debug.Log("Volume reached: " + audioSource.volume);
    }

    public void PauseMusic()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        //Debug.Log("Volume manually set to: " + volume);
    }
}
