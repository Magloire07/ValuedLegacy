using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class WordFadeController : MonoBehaviour
{
    public TextMeshProUGUI[] words;
    public float fadeDuration = 1.50f;
    public float displayDuration = 1.5f;

    private void OnEnable()
    {
        StartCoroutine(PlaySequence());
    }

    private IEnumerator PlaySequence()
    {
        foreach (var word in words)
        {
            word.gameObject.SetActive(true);

            // Fade in
            yield return StartCoroutine(FadeText(word, 0f, 1f));

            // Wait while visible
            yield return new WaitForSeconds(displayDuration);

            // Fade out
            yield return StartCoroutine(FadeText(word, 1f, 0f));

            word.gameObject.SetActive(false);
        }
    }

    private IEnumerator FadeText(TextMeshProUGUI text, float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color color = text.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            color.a = alpha;
            text.color = color;
            yield return null;
        }

        color.a = endAlpha;
        text.color = color;
    }
}
