using Core.Application.Interfaces;
using Core.Domain.Entities;
using Core.Domain.IResponsitories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public class TheLoaiServices : ITheLoaiServices
    {
        private readonly ITheLoaiRepository _repository;
        private readonly ILogger<TheLoaiServices> _logger;

        public TheLoaiServices(ITheLoaiRepository repository, ILogger<TheLoaiServices> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> AddService(TheLoaiEntity model)
        {
            return await _repository.InsertAsync(model);
        }
        public async Task<bool> UpdateService(int id, TheLoaiEntity model)
        {
            return await _repository.UpdateAsync(id, model);
        }
        public async Task<bool> DeleteService(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<TheLoaiEntity>> GetAllService()
        {
            var data = await _repository.GetAllAsync();
            return data;
        }

        public async Task<TheLoaiEntity> GetServiceById(int id)
        {
            var data = await _repository.GetAsync(id);
            return data;
        }
    }
}
