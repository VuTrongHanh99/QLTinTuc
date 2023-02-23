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
    public class MenuMainServices : IMenuMainServices
    {
        private readonly IMenuMainRepository _repository;
        private readonly ILogger<MenuMainServices> _logger;

        public MenuMainServices(IMenuMainRepository repository, ILogger<MenuMainServices> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> AddService(MenuMainEntity model)
        {
            return await _repository.InsertAsync(model);
        }
        public async Task<bool> UpdateService(int id, MenuMainEntity model)
        {
            return await _repository.UpdateAsync(id, model);
        }
        public async Task<bool> DeleteService(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<MenuMainEntity>> GetAllService()
        {
            var data = await _repository.GetAllAsync();
            return data;
        }

        public async Task<MenuMainEntity> GetServiceById(int id)
        {
            var data = await _repository.GetAsync(id);
            return data;
        }

        public async Task<List<object>> GetServiceMenuMain(int parentid)
        {
            var resultMenuMain= new List<object>();
            var data = await _repository.GetMenuMainAsync(parentid);
            foreach (var item in data)
            {
                resultMenuMain.Add(new { item.MenuId, item.MenuName });
            }
            return resultMenuMain;
        }
    }
}
