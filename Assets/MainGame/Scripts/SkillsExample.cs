public class GameExample : MonoBehaviour
{
    public SkillManager skillManager;

    void Start()
    {
        skillManager = gameObject.AddComponent<SkillManager>();

        // ajouter des comp�tences Eloquence et Agilit�
        skillManager.AddSkill("�loquence", 20f, "eloquence_icon");
        skillManager.AddSkill("Agilit�", 15f, "agility_icon");

        Skill skill = skillManager.GetSkill("�loquence");
        if (skill != null)
        {
            Debug.Log($"Comp�tence : {skill.SkillName} | Valeur : {skill.Value}");
        }

        skillManager.ModifySkillValue("Agilit�", 25f);
        skillManager.RemoveSkill("�loquence");
    }
}
