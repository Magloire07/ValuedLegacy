public class GameExample : MonoBehaviour
{
    public SkillManager skillManager;

    void Start()
    {
        skillManager = gameObject.AddComponent<SkillManager>();

        // ajouter des compétences Eloquence et Agilité
        skillManager.AddSkill("Éloquence", 20f, "eloquence_icon");
        skillManager.AddSkill("Agilité", 15f, "agility_icon");

        Skill skill = skillManager.GetSkill("Éloquence");
        if (skill != null)
        {
            Debug.Log($"Compétence : {skill.SkillName} | Valeur : {skill.Value}");
        }

        skillManager.ModifySkillValue("Agilité", 25f);
        skillManager.RemoveSkill("Éloquence");
    }
}
