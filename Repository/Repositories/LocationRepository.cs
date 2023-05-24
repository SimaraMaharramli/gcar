using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
	public class LocationRepository : Repository<Location>, ILocationRepository
	{
		private readonly AppDbContext _context;
		private readonly DbSet<Location> entities;

		public LocationRepository(AppDbContext context) : base(context)
		{
			_context = context;
			entities = _context.Set<Location>();
		}

		public async Task<Location> GetLocationtAsync(int id)
		{
			var entity = await entities.FirstOrDefaultAsync(m => m.Id == id);

			if (entity is null) throw new NullReferenceException();

			return entity;
		}
		public async Task<Location> GetSubLocationtAsync(int id)
		{
			var entity = await entities.Include(m => m.SubLocation).FirstOrDefaultAsync();

			if (entity is null) throw new NullReferenceException();

			return entity;
		}
	}
}

