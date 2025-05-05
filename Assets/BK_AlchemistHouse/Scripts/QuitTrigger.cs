using UnityEngine;
using System.Collections; // Pour les coroutines
using UnityEngine.UI; // Pour l'interface utilisateur
using TMPro; // Pour le texte

public class QuitTrigger : MonoBehaviour
{
    public GameObject world3DObjects;
    public GameObject game2DCanvas;
    public Image fadeImage; // Image noire pour l'effet de transition
    public float fadeDuration = 1f; // Durée de la transition

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered) return;
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            TransitionTo2D(); 
        }
    }

    private void TransitionTo2D()
    {

        if (game2DCanvas != null)
            game2DCanvas.SetActive(true);

        // Débloquer et rendre visible la souris
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Désactiver les objets 3D et activer le Canvas 2D
        if (world3DObjects != null)
        {
            world3DObjects.SetActive(false);
            Destroy(world3DObjects); // Détruire les objets 3D
        }
    }

}
