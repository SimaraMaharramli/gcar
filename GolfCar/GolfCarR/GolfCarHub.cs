using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.Services.DTOs.Order;
using Service.Services.Interfaces;

namespace GolfCar.GolfCarR
{
    public class GolfCarHub:Hub
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _dbContext;
        private readonly ILocationService _locationser;
        private readonly IRepository<Order> _repository;
        private readonly IOrderRepository _orderrepository;


        public GolfCarHub(UserManager<AppUser> userManager, AppDbContext dbContext, ILocationService locationser, IRepository<Order> repository, IOrderRepository orderrepository)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _locationser = locationser;
            _repository = repository;
            _orderrepository = orderrepository;
        }
      
        public async Task OrderTaxi(OrderDto request)
        {
            var user = await _userManager.GetUserAsync(Context.User);
            if (user == null)
            {
                await Clients.Caller.SendAsync("Error", "User not found.");
                return;
            }

            var driver = await _dbContext.Drivers.FindAsync(request.DriverId);
            if (driver == null)
            {
                await Clients.Caller.SendAsync("Error", "Driver not found.");
                return;
            }
            var order = new Order
            {
                AppUserId = user.Id,
                Locations=request.Location,
                SubLocations=request.SubLocation,
                Destination=request.Destination,
                DriverId = driver.Id,
                FareDetails = "5AZN",
                Status = OrderStatus.Pending,
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            await Clients.Caller.SendAsync("ReceiveTaxiOrderResponse", order);
            await Clients.AllExcept(Context.ConnectionId).SendAsync("NewTaxiOrder", order);
        }

        public async Task ChangeOrderStatus(int orderId,OrderStatus newstatus)
        {
            var order = await _repository.GetAsync(orderId);

            if (order == null)
            {
                return;
            }
            order.Status = newstatus;
            await _repository.UpdateAsync(order);
            await Clients.All.SendAsync("OrderStatusChanged", orderId, order.Status);
        }
    }
}
