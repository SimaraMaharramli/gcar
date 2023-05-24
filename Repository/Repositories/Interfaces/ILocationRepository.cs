using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<Location> GetLocationtAsync(int id);
        Task<Location> GetSubLocationtAsync(int id);

    }
}
