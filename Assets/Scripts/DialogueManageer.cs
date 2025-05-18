
using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class DialogueManageer : MonoBehaviour
{

    [TextArea(3, 10)] public string[] dialogueLines;
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;

    public float typingSpeed = 0.05f;          // Temps entre chaque lettre
    public float lineDisplayDuration = 1.5f;   // Temps après que la ligne soit complètement tapée

    private int idx = 0;
    private AstronautController player;

    public Transform terre;
    public Camera mainCamera;



    void Awake()
    {
        dialoguePanel.SetActive(false);
    }

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        idx = 0;
        player = FindFirstObjectByType<AstronautController>();

        if (player != null)
            player.canMove = false;

        dialoguePanel.SetActive(true);
        StartCoroutine(ShowDialogueSequence());
    }

    IEnumerator ShowDialogueSequence()
    {
        while (idx < dialogueLines.Length)
        {
            yield return StartCoroutine(TypeLine(dialogueLines[idx]));
            yield return new WaitForSeconds(lineDisplayDuration);
            idx++;
        }

        EndDialogue();
    }

    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        gameObject.SetActive(false); // désactive ce script

        SceneManager.LoadScene("MainGame");


    }
}