using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<AppUser>> GetAllAsync();
        Task<IList<string>> GetRoleAsync(string email);
        Task ChangeRole(string id);
    }
}
