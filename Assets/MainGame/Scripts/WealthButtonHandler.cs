using UnityEngine;

public class WealthButtonHandler : MonoBehaviour
{
    public GameObject popupPanel;
    public TMPro.TMP_Text descriptionText;

    public void OnClick()
    {
        //descriptionText.text = "Représente votre capital financier accumulé.";
        popupPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        if (popupPanel != null)
            popupPanel.SetActive(false);
    }
}
