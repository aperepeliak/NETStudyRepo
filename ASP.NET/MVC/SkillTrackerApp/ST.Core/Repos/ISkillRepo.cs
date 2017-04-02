using ST.Core.Models;
using System.Collections.Generic;

namespace ST.Core.Repos
{
    public interface ISkillRepo
    {
        void Add(Skill skill);
        Skill Remove(Skill skill);

        IEnumerable<Skill> GetAll();
        IEnumerable<Skill> GetSkillsByCategory(int categoryId);
    }
}
