using AutoMapper;
using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.Services.DTOs.Location;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LocationService : ILocationService
    {

        private readonly ILocationRepository _repository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public LocationService(ILocationRepository repository, IMapper mapper, AppDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateAsync(LocationCreateDto eventCreateDto)
        {
            var model = _mapper.Map<Location>(eventCreateDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var levent = await _repository.GetAsync(id);
            await _repository.DeleteAsync(levent);
        }

        public async Task<List<LocationDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<LocationDto>>(model);
            return res;
        }

        public async Task<LocationDto> GetByIdAsync(int id)
        {
            var model = await _repository.GetLocationtAsync(id);
            var res = _mapper.Map<LocationDto>(model);
            return res;
        }

        public async Task UpdateAsync(int id, LocationEditDto levent)
        {
            var entity = await _repository.GetLocationtAsync(id);

            _mapper.Map(levent, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task<LocationDto> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<LocationDto>(model);
            return res;
        }



        public async Task<IEnumerable<LocationDto>> GetAllNameAsync(string search)
        {
            return _mapper.Map<IEnumerable<LocationDto>>(await _repository.FindAllAsync(m => m.Name.Contains(search)));
        }


    }
}
