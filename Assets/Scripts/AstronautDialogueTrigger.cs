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
            Debug.Log("Collision détectée avec le joueur. Dialogue lancé.");

            var dialogueManager = FindFirstObjectByType<DialogueManageer>();
            if (dialogueManager != null)
                dialogueManager.gameObject.SetActive(true);
        }
    }
}
