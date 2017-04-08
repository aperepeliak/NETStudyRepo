using ST.Core.Models;
using System.Collections.Generic;

namespace ST.Core.Repos
{
    public interface ISkillRepo
    {
        void Add(Skill skill);
        void Remove(Skill skill);
        Skill GetSkill(int id);
        IEnumerable<Skill> GetAll();
        IEnumerable<Skill> GetSkillsByCategory(int categoryId);
    }
}
