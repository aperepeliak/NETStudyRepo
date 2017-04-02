using ST.Core.Repos;

namespace ST.Core
{
    public interface IUnitOfWork
    {
        ISkillRepo Skills { get; }
        ICategoryRepo Categories { get; }

        void Complete();
    }
}
