using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Order> entities;
        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Order>();
        }
        public async Task UpdateOrder(Order order, OrderStatus newStatus)
        {
            order.Status = newStatus;
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
