using UnityEngine;

[System.Serializable]
public class Skill
{
    [SerializeField] private string skillName;
    [SerializeField] private float value;
    [SerializeField] private string iconName;

    [System.NonSerialized] private Sprite iconSprite;

    public Skill(string skillName, float value, string iconName)
    {
        this.skillName = skillName;
        this.value = value;
        this.iconName = iconName;
        LoadIcon();
    }

    private void LoadIcon()
    {
        if (!string.IsNullOrEmpty(iconName))
        {
            iconSprite = Resources.Load<Sprite>("Icons/" + iconName);
            if (iconSprite == null)
                Debug.LogWarning($"Icône non trouvée pour la compétence '{skillName}' dans Resources/Icons/{iconName}");
        }
    }

    // Getters explicites
    public string GetSkillName()
    {
        return skillName;
    }

    public float GetValue()
    {
        return value;
    }

    public string GetIconName()
    {
        return iconName;
    }

    public Sprite GetIcon()
    {
        if (iconSprite == null)
            LoadIcon();
        return iconSprite;
    }

    // Setters
    public void SetValue(float newValue)
    {
        value = newValue;
    }

    public void SetIcon(string newIconName)
    {
        iconName = newIconName;
        LoadIcon();
    }

    public void SetSkillName(string newName)
    {
        skillName = newName;
    }
}
