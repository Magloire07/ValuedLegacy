using UnityEngine;

public class SkillButtonHandler : MonoBehaviour
{
    public GameObject popupPanel;
    public TMPro.TMP_Text descriptionText;

    public void OnClick()
    {
       // descriptionText.text = "Voici les compétences que votre personnage a acquises.";
        popupPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        if (popupPanel != null)
            popupPanel.SetActive(false);
    }
}
