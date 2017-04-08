using ST.Core.Repos;
using System.Collections.Generic;
using System.Linq;
using ST.Core.Models;
using System.Data.Entity;

namespace ST.DAL.Repos
{
    public class SkillRepo : ISkillRepo
    {
        private readonly ApplicationDbContext _context;

        public SkillRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Skill skill)       => _context.Skills.Add(skill);
        public void Remove(Skill skill)    => _context.Entry(skill).State = EntityState.Deleted;
        public Skill GetSkill(int id)      => _context.Skills.Find(id);

        public IEnumerable<Skill> GetAll() => _context.Skills
                                                .Include(s => s.Category);

        public IEnumerable<Skill> GetSkillsByCategory(int categoryId)
                                           => _context.Skills
                                                .Include(s => s.Category)
                                                .Where(s => s.CategoryId == categoryId);
    }
}
