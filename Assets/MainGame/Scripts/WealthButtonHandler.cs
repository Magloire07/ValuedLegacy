using UnityEngine;

public class WealthButtonHandler : MonoBehaviour
{
    public GameObject popupPanel;
    public TMPro.TMP_Text descriptionText;

    public void OnClick()
    {
        //descriptionText.text = "Repr�sente votre capital financier accumul�.";
        popupPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        if (popupPanel != null)
            popupPanel.SetActive(false);
    }
}
