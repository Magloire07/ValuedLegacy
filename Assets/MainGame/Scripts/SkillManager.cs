using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private List<Skill> skills = new List<Skill>();

    // Ajouter une compétence
    public void AddSkill(string name, float value, string iconName)
    {
        Skill newSkill = new Skill(name, value, iconName);
        skills.Add(newSkill);
    }

    // Supprimer une compétence par nom
    public bool RemoveSkill(string name)
    {
        Skill skill = skills.Find(s => s.SkillName == name);
        if (skill != null)
        {
            skills.Remove(skill);
            return true;
        }
        return false;
    }

    // Modifier la valeur d'une compétence
    public bool ModifySkillValue(string name, float newValue)
    {
        Skill skill = skills.Find(s => s.SkillName == name);
        if (skill != null)
        {
            skill.Value = newValue;
            return true;
        }
        return false;
    }

    // Changer l'icône
    public bool ChangeSkillIcon(string name, string newIconName)
    {
        Skill skill = skills.Find(s => s.SkillName == name);
        if (skill != null)
        {
            skill.SetIcon(newIconName);
            return true;
        }
        return false;
    }

    // Obtenir une compétence
    public Skill GetSkill(string name)
    {
        return skills.Find(s => s.SkillName == name);
    }

    // Retourner toutes les compétences
    public List<Skill> GetAllSkills()
    {
        return skills;
    }
}
