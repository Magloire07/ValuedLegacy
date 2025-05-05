using UnityEngine;
using UnityEngine.UI;
using TMPro; // Ajout nécessaire pour TextMeshProUGUI
using System.Collections.Generic;

public class SkillButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab;      // Le prefab du bouton (avec un TextMeshProUGUI et une Image)
    public Transform panelParent;        // Le panel contenant les boutons

    void Start()
    {
        GenerateSkillButtons();
    }

    void GenerateSkillButtons()
    {
        List<Skill> allSkills = SkillManager.Instance.GetAllSkills();

        foreach (Skill skill in allSkills)
        {
            GameObject newButton = Instantiate(buttonPrefab, panelParent);

            // Remplace "Text" par "TextMeshProUGUI"
            TextMeshProUGUI textComponent = newButton.GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null)
                textComponent.text = $"{skill.GetSkillName()} : {skill.GetValue()}";

            // Définir l’image du bouton si icône trouvée
            Image imageComponent = newButton.GetComponent<Image>();
            Sprite icon = skill.GetIcon();
            if (imageComponent != null && icon != null)
                imageComponent.sprite = icon;

            // Ajouter l’événement onClick
            Button btn = newButton.GetComponent<Button>();
            if (btn != null)
            {
                string nameCopy = skill.GetSkillName();
                float valueCopy = skill.GetValue();
                btn.onClick.AddListener(() => ShowSkillPopup(nameCopy, valueCopy));
            }
        }
    }

    void ShowSkillPopup(string skillName, float value)
    {
        Debug.Log($"Popup : {skillName} ({value})");
        // Ici tu peux appeler une UI de popup réelle
    }
}
