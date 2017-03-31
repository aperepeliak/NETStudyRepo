using BAL.Repos;

namespace BAL
{
    public interface IUnitOfWork
    {
        IClientProfileRepo ClientProfiles { get; }

        void Commit();
    }
}
