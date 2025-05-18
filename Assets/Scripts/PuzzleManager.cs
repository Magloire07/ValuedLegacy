/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public GameObject stationSpatiale;
    public Transform focusTarget;
    public Camera mainCamera;
    public float focusDuration = 3f;

    public static PuzzleManager instance;
    public int totalPieces = 6;
    public int piecesCollected = 0;

    public TextMeshProUGUI scoreText;
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;

    public Transform spaceStation;
    public Transform camera;

    private bool focused = false;

    void Awake()
    {
        instance = this;
        messagePanel.SetActive(false);  
    }

    public void CollectPiece(GameObject piece)
    {
        piecesCollected++;
        UpdateScore();
        Debug.Log($"Pièce récupérée ({piecesCollected}/{totalPieces})");

        Destroy(piece);

        if (piecesCollected == totalPieces)
        {
            PuzzleComplete();
        }
    }

    void UpdateScore()
    {
        if (scoreText != null)
            scoreText.text = $"Pièces : {piecesCollected} / {totalPieces}";
    }

    void PuzzleComplete()
    {
        Debug.Log("Tous les morceaux récupérés !");
        ShowMessage();

        StartCoroutine(FocusOnStation());
    }

    public void ShowMessage()
    {
        messagePanel.SetActive(true);
        messageText.text = "Il faut te diriger vers la station spatiale.";
    }
    IEnumerator FocusOnStation()
    {
        Vector3 originalPosition = mainCamera.transform.position;
        Quaternion originalRotation = mainCamera.transform.rotation;

        Vector3 targetPosition = focusTarget.position + new Vector3(0, 2, -5);
        Quaternion targetRotation = Quaternion.LookRotation(focusTarget.position - targetPosition);

        float elapsed = 0f;

        while (elapsed < focusDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsed / focusDuration);
            mainCamera.transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, elapsed / focusDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

    }
    public void CloseMessage()
    {
        messagePanel.SetActive(false);
    }
}
*/
using System.Collections;
using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    public int totalPieces = 6;
    public int piecesCollected = 0;

    public TextMeshProUGUI scoreText;

    // Nouveau message panel propre (avec MessageText et FermerButton à l’intérieur)
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;

    public Camera mainCamera;
    public Camera focusCamera;

    public Transform focusTarget;
    public float focusDuration = 3f;

    //je l'ajoute ici sinon il pose problème ailleurs
    public FirstPersonLook lookScript;
    void Awake()
    {
        instance = this;
        messagePanel.SetActive(false);
    }

    public void CollectPiece(GameObject piece)
    {
        piecesCollected++;
        UpdateScore();
        Debug.Log($"Pièce récupérée ({piecesCollected}/{totalPieces})");

        Destroy(piece);

        if (piecesCollected == totalPieces)
        {
            PuzzleComplete();
        }
    }

    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Pièces : {piecesCollected} / {totalPieces}";
        }
    }

    void PuzzleComplete()
    {
        Debug.Log("Tous les morceaux récupérés !");
        ShowMessage();
        StartCoroutine(FocusOnStation());
    }

    public void ShowMessage()
    {/*
        messagePanel.SetActive(true);
        messageText.text = "Bravo ! Mainteant que tu as trouvé toutes les piècecs, il faut te diriger vers la station spatiale.";
        */
        messagePanel.SetActive(true);
        messageText.text = "Bravo ! Maintenant que tu as trouvé toutes les pièces, il faut te diriger vers la station spatiale.";

        // Affiche le curseur
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Désactive le script de rotation
        lookScript.enabled = false;
    }

    public void CloseMessage()
    {
        /*
        messagePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        */
        messagePanel.SetActive(false);

        // Cache le curseur
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Réactive la rotation de la caméra
        lookScript.enabled = true;
       
        focusCamera.enabled = false;
        mainCamera.enabled = true;
    }

    /*
    IEnumerator FocusOnStation()
    {
        Vector3 originalPosition = mainCamera.transform.position;
        Quaternion originalRotation = mainCamera.transform.rotation;

        //on active spaceship
        focusTarget.gameObject.SetActive(true);

        Vector3 targetPosition = focusTarget.position + new Vector3(0, 2, -5);
        Quaternion targetRotation = Quaternion.LookRotation(focusTarget.position - targetPosition);

        float elapsed = 0f;

        while (elapsed < focusDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsed / focusDuration);
            mainCamera.transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, elapsed / focusDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }*/
    IEnumerator FocusOnStation()
    {
        // Activer le vaisseau si nécessaire
        focusTarget.gameObject.SetActive(true);

        // Activer la caméra de focus et désactiver celle du joueur
        mainCamera.enabled = false;
        focusCamera.enabled = true;

        Vector3 startPos = focusCamera.transform.position;
        Quaternion startRot = focusCamera.transform.rotation;

        Vector3 targetPos = focusTarget.position + new Vector3(0, 2, -5);
        Quaternion targetRot = Quaternion.LookRotation(focusTarget.position - targetPos);

        float elapsed = 0f;

        while (elapsed < focusDuration)
        {
            focusCamera.transform.position = Vector3.Lerp(startPos, targetPos, elapsed / focusDuration);
            focusCamera.transform.rotation = Quaternion.Slerp(startRot, targetRot, elapsed / focusDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        focusCamera.transform.position = targetPos;
        focusCamera.transform.rotation = targetRot;
    }

}
