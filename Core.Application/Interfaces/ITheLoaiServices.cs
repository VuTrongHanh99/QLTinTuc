using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface ITheLoaiServices
    {

        public Task<List<TheLoaiEntity>> GetAllService();

        public Task<TheLoaiEntity> GetServiceById(int id);

        public Task<bool> AddService(TheLoaiEntity model);

        public Task<bool> UpdateService(int id,TheLoaiEntity model);

        public Task<bool> DeleteService(int id);
    }
}
