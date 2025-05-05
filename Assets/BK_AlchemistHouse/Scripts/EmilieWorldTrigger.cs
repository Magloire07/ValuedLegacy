using UnityEngine;
using System.Collections; // Pour les coroutines
using UnityEngine.UI; // Pour l'interface utilisateur
using TMPro; // Pour le texte
using UnityEngine.SceneManagement;

public class EmilieWorldTrigger : MonoBehaviour
{
    public GameObject game2DCanvas;
    public GameObject loadingUI; // Contient le spinner

    public void ReturnToWorld2D()
    {

        if (game2DCanvas != null)
            game2DCanvas.SetActive(true);

        // Débloquer et rendre visible la souris
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void TransitionTo3D()
    {

       // SceneManager.LoadScene("EmilieScene");

        // Verrouiller et cacher la souris pour revenir en mode 3D
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(LoadAsyncScene());


    }



    private IEnumerator LoadAsyncScene()
    {
        Debug.Log("Début du chargement de la scène...");
        loadingUI.SetActive(true); // Affiche le spinner

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("EmilieScene");
        asyncLoad.allowSceneActivation = false;

        // Attendre que le chargement soit presque terminé
        while (asyncLoad.progress < 0.9f)
        {
            Debug.Log($"Progression du chargement : {asyncLoad.progress}");
            yield return null;
        }

        Debug.Log("Chargement presque terminé. Désactivation du Canvas 2D.");
        if (game2DCanvas != null)
            game2DCanvas.SetActive(false);


        Debug.Log("Activation de la scène.");
        asyncLoad.allowSceneActivation = true;
    }

}
