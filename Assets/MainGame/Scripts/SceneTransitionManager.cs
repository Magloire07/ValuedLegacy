using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public GameObject world2D;
    public GameObject camera2D;
    public GameObject world3D;
    public GameObject camera3D;
    public GameObject sequencer;
    public Image fadeOverlay;
    public float fadeDuration = 15f;

    private void OnEnable()
    {
        StartCoroutine(TransitionTo3D());
    }

    private IEnumerator TransitionTo3D()
    {

        SwitchTo3D();

        if (fadeOverlay != null)
        {
            yield return StartCoroutine(Fade(1f, 0f)); // Réapparition
        }
    }

    public void SwitchTo3D()
    {
        world2D.SetActive(false);
        camera2D.SetActive(false);
        world3D.SetActive(true);
        camera3D.SetActive(true);
        Destroy(world2D, 2f); // Détruire le monde 2D après la transition
        Destroy(camera2D, 2f); // Détruire la caméra 2D après la transition
        Destroy(sequencer, 2f);
        Debug.Log("Passage au monde 3D");
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        Color color = fadeOverlay.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeDuration;
            float easedT = t * t; // Courbe Ease-In Quadratique (lent puis rapide)
            float alpha = Mathf.Lerp(startAlpha, endAlpha, easedT);
            color.a = alpha;
            fadeOverlay.color = color;
            yield return null;
        }

        // Assurer que la valeur finale est appliquée
        color.a = endAlpha;
        fadeOverlay.color = color;
    }
}
