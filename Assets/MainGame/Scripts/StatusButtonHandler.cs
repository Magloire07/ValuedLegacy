using UnityEngine;

public class StatusButtonHandler : MonoBehaviour
{
    public GameObject popupPanel;
    public TMPro.TMP_Text descriptionText;

    public void OnClick()
    {
        //descriptionText.text = "Votre position actuelle dans la société.";
        popupPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        if (popupPanel != null)
            popupPanel.SetActive(false);
    }
}
