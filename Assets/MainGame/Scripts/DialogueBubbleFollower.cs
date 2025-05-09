using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBubbleFollower : MonoBehaviour
{
    public Transform target; // Le joueur
    public Vector3 offset = new Vector3(0, 2f, 0); // D�calage au-dessus de la t�te
    public Camera mainCamera;
    public TextMeshProUGUI dialogueText;

    void Update()
    {
        if (target == null || mainCamera == null) return;

        Vector3 worldPos = target.position + offset;
        Vector3 screenPos = mainCamera.WorldToScreenPoint(worldPos);

        transform.position = screenPos;
    }

    public void ShowText(string text, float duration = 2f)
    {
        dialogueText.text = text;
        gameObject.SetActive(true);
        CancelInvoke(nameof(Hide));
        Invoke(nameof(Hide), duration);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
