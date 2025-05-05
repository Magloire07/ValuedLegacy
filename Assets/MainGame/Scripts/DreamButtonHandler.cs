using UnityEngine;

public class DreamButtonHandler : MonoBehaviour
{
    public GameObject popupPanel;
    public TMPro.TMP_Text descriptionText;

    public void OnClick()
    {
        //descriptionText.text = "Indique votre progression vers votre objectif de vie.";
        popupPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        if (popupPanel != null)
            popupPanel.SetActive(false);
    }
}
