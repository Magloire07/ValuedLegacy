using UnityEngine;
using System.Collections; // Pour les coroutines
using UnityEngine.UI; // Pour l'interface utilisateur
using TMPro; // Pour le texte

public class MissionTrigger2 : MonoBehaviour
{
    public GameObject world3DObjects;
    public GameObject game2DCanvas;
    public Image fadeImage; // Image noire pour l'effet de transition
    public float fadeDuration = 1f; // Dur�e de la transition

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

        // D�sactiver les objets 3D et activer le Canvas 2D
        if (world3DObjects != null)
            world3DObjects.SetActive(false);

        if (game2DCanvas != null)
            game2DCanvas.SetActive(true);

        // D�bloquer et rendre visible la souris
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        // D�sactivation du trigger apr�s activation du mini-jeu
        gameObject.SetActive(false);
        Debug.Log("Mini-jeu de vocabulaire lanc� !");
    }

    public void ReturnToWorld3D()
    {

        // D�sactiver le Canvas 2D et activer les objets 3D
        if (game2DCanvas != null)
            game2DCanvas.SetActive(false);

        if (world3DObjects != null)
            world3DObjects.SetActive(true);

        // Verrouiller et cacher la souris pour revenir en mode 3D
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        isTriggered = false; // Permet de retrigger si n�cessaire
        Debug.Log("Retour dans le monde 3D !");
    }

}
