using ST.Core.Repos;

namespace ST.Core
{
    public interface IUnitOfWork
    {
        ISkillRepo      Skills      { get; }
        ICategoryRepo   Categories  { get; }
        IDeveloperRepo  Developers  { get; }
        IManagerRepo    Managers    { get; }

        void Complete();
    }
}
