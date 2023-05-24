using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.Services.DTOs.SubLocation;
using Service.Services.Interfaces;

namespace Dashboard.Controllers
{
    public class SubLocationController : Controller
    {
		private readonly ILocationService _locationService;
		private readonly ISubLocationService _sublocationService;
		private readonly IMapper _mapper;
		private readonly AppDbContext _context;
		private readonly IRepository<SubLocation> _repository;
		public SubLocationController(IMapper mapper ,AppDbContext context, ISubLocationService sublocationService, ILocationService locationService,IRepository<SubLocation> repository)
        {
            _sublocationService = sublocationService;
            _context = context;
			 _mapper=mapper;
			_locationService = locationService;
			_repository = repository;

		}
		public async Task<IActionResult> Index()
		{
			var relocal = await _repository.GetAllIncludeAsync(x => x.SoftDelete, "Location");
			return View(relocal.ToList());
		}
		[HttpGet]
		public async Task<IActionResult> Create()
        {
			var locations = await _locationService.GetAllAsync();
			ViewBag.Locations = locations;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(SubLocationCreateDto sublocal)
        {
			await _sublocationService.CreateAsync(sublocal);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Update()
		{
			var locations = await _locationService.GetAllAsync();
			ViewBag.Locations = locations;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update( int id,SubLocationEditDto sublocal)
		{
			await _sublocationService.UpdateAsync(id,sublocal);
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
        public async Task<IActionResult> Delete(int id)
        { 
			await _sublocationService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
