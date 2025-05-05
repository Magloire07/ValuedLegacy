using UnityEngine;
using System.Collections; // Pour les coroutines
using UnityEngine.UI; // Pour l'interface utilisateur
using TMPro; // Pour le texte
using UnityEngine.SceneManagement;

public class G2WorldTrigger : MonoBehaviour
{
    public GameObject game2DCanvas;

    public void ReturnToWorld2DFromG2()
    {

        if (game2DCanvas != null)
            game2DCanvas.SetActive(true);

        // Débloquer et rendre visible la souris
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void TransitionTo3DG2()
    {

        // Désactiver le Canvas 2D et activer les objets 3D
        if (game2DCanvas != null)
            game2DCanvas.SetActive(false);

        SceneManager.LoadScene("G2Scene");

        // Verrouiller et cacher la souris pour revenir en mode 3D
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

}
