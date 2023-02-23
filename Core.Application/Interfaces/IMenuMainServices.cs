using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IMenuMainServices
    {
        public Task<List<MenuMainEntity>> GetAllService();

        public Task<MenuMainEntity> GetServiceById(int id);
        public Task<List<object>> GetServiceMenuMain(int parentid);

        public Task<bool> AddService(MenuMainEntity model);

        public Task<bool> UpdateService(int id, MenuMainEntity model);

        public Task<bool> DeleteService(int id);
    }
}
