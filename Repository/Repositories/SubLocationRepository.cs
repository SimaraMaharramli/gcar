using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SubLocationRepository : Repository<SubLocation>, ISubLocationRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<SubLocation> entities;

        public SubLocationRepository(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<SubLocation>();
        }

        public async Task<SubLocation> GetSubLocationAsync(int id)
        {
            var entity = await entities.Include(m => m.Location).FirstOrDefaultAsync(m => m.Id == id);

            if (entity is null) throw new NullReferenceException();

            return entity;
        }

    }
}
