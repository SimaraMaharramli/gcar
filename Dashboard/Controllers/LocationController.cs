using Dashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.DTOs.Account;
using Service.Services.DTOs.Location;
using Service.Services.Interfaces;
using Repository.Repositories.Interfaces;
using System.Diagnostics;
using Domain.Entities;

namespace Dashboard.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly AppDbContext _context;
		private readonly IRepository<Location> _repository;
		public LocationController( AppDbContext context, ILocationService locationService, IRepository<Location> repository)
        {
            _locationService = locationService;
			_context= context;
			_repository = repository;

		}

        public async Task< IActionResult> Index()
        {
            var relocal= await _repository.GetAllIncludeAsync(x=>x.SoftDelete , "SubLocation");

            return View(relocal.ToList());
        }


		public  IActionResult Create()
		{
            return View();
		}
        [HttpPost]
        public async Task<IActionResult> Create(LocationCreateDto dto)
		{
            await _locationService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
		{
              await _locationService.DeleteAsync(id); 
			return RedirectToAction(nameof(Index));
		}
        public IActionResult Update()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> Update(int id,LocationEditDto dto)
		{
              await _locationService.UpdateAsync(id,dto); 
			return RedirectToAction(nameof(Index));
		}


		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}