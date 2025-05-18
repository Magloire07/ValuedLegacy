using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautDialogueTrigger : MonoBehaviour
{
    private bool dialogueTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dialogueTriggered)
        {
            dialogueTriggered = true;
            Debug.Log("Collision d�tect�e avec le joueur. Dialogue lanc�.");

            var dialogueManager = FindFirstObjectByType<DialogueManageer>();
            if (dialogueManager != null)
                dialogueManager.gameObject.SetActive(true);
        }
    }
}
