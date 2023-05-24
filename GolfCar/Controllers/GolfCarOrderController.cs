using Domain.Entities;
using Service.Services.DTOs.Order;
using GolfCar.GolfCarR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Repository.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace GolfCar.Controllers
{

    //  "email": "meherremlisimare02@gmail.com",---user
    //  "password": "123456Ms??"

    //"email": "sa@gmail.com",
    // "password": "123456Aa?",
    public class GolfCarOrderController : AppController
    {
        private readonly IHubContext<GolfCarHub> _hubContext;
        private readonly AppDbContext _dbContext;

        public GolfCarOrderController(IHubContext<GolfCarHub> hubContext, AppDbContext dbContext)
        {
            _hubContext = hubContext;
            _dbContext = dbContext;
        }

        [HttpPost]
        
        public async Task<IActionResult> PlaceOrder(OrderDto request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var driver = _dbContext.Drivers.FirstOrDefault(d => d.Id == request.DriverId);
            if (driver == null)
            {
                return BadRequest("Invalid driver ID.");
            }

            var order = new Order
            {
                AppUserId = userId,
                Locations = request.Location,
                SubLocations = request.SubLocation,
                Destination = request.Destination,
                DriverId = driver.Id,
                FareDetails = "5AZN",
                Status = OrderStatus.Pending,
            };
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("NewTaxiOrder", order);

            return Ok();
        }
    }
}
