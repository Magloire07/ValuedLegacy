using UnityEngine;

[System.Serializable]
public class Skill
{
    [SerializeField] private string skillName;
    [SerializeField] private float value;
    [SerializeField] private string iconName;

    private Sprite iconSprite;

    public Skill(string skillName, float value, string iconName)
    {
        this.skillName = skillName;
        this.value = value;
        this.iconName = iconName;
        LoadIcon();
    }

    private void LoadIcon()
    {
        iconSprite = Resources.Load<Sprite>("Icons/" + iconName);
        if (iconSprite == null)
            Debug.LogWarning($"Icône non trouvée pour la compétence '{skillName}' dans Resources/Icons/{iconName}");
    }

    // Accesseurs
    public string SkillName => skillName;
    public float Value
    {
        get => value;
        set => this.value = value;
    }
    public string IconName => iconName;
    public Sprite Icon => iconSprite;

    // Méthode pour changer l’icône dynamiquement
    public void SetIcon(string newIconName)
    {
        iconName = newIconName;
        LoadIcon();
    }

    // Méthode pour modifier le nom
    public void SetSkillName(string newName)
    {
        skillName = newName;
    }
}
