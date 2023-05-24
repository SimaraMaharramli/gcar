using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Services.DTOs.SubLocation;
using Domain.Entities;
using Repository.Repositories.Interfaces;

namespace Service.Services
{
    public class SubLocationService : ISubLocationService
    {
        private readonly ISubLocationRepository _repository;
        private readonly IMapper _mapper;
        public SubLocationService(ISubLocationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(SubLocationCreateDto locationCreateDto)
        {
            var model = _mapper.Map<SubLocation>(locationCreateDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var levent = await _repository.GetAsync(id);
            await _repository.DeleteAsync(levent);
        }

        public async Task<List<SubLocationDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<SubLocationDto>>(model);
            return res;
        }

        public async Task<SubLocationDto> GetByIdAsync(int id)
        {
            var model = await _repository.GetSubLocationAsync(id);
            var res = _mapper.Map<SubLocationDto>(model);
            return res;
        }


        public async Task<SubLocationDto> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<SubLocationDto>(model);
            return res;
        }

        public async Task<List<SubLocationDto>> GetByLocationId(int id)
        {
            var model = await _repository.FindAllAsync(m => m.LocationId == id);
            var res = _mapper.Map<List<SubLocationDto>>(model);
            return res;
        }

        public async Task<IEnumerable<SubLocationDto>> GetAllNameAsync(string search)
        {
            return _mapper.Map<IEnumerable<SubLocationDto>>(await _repository.FindAllAsync(m => m.Name.Contains(search)));
        }

        public async Task<SubLocationPaginateDto> Paginate(int num)
        {
            int skipdata = num * 10;
            var model = await _repository.GetAllAsync();
            IEnumerable<SubLocation> enumerable = model as IEnumerable<SubLocation>;
            var paginate = enumerable.Skip(skipdata).Take(10);
            var res = _mapper.Map<IEnumerable<SubLocationDto>>(paginate);
            SubLocationPaginateDto eventPaginateDto = new SubLocationPaginateDto();
            eventPaginateDto.Length = model.Count();
            eventPaginateDto.SubLocationDtos = res;
            return eventPaginateDto;
        }

        public async Task UpdateAsync(int id, SubLocationEditDto levent)
        {
            var entity = await _repository.GetSubLocationAsync(id);

            _mapper.Map(levent, entity);

            await _repository.UpdateAsync(entity);
        }
    }

}
