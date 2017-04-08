using System.ComponentModel.DataAnnotations;

namespace ST.Core.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public void Update(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
