using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface ISubLocationRepository : IRepository<SubLocation>
    {
        Task<SubLocation> GetSubLocationAsync(int id);
    }
}
