using CalendarManager.Infrastructure.IGenericRepositories;
using CalendarManager.Model;

namespace CalendarManager.DataAccess.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindUserByPublicKey(string publicKey);
    }
}