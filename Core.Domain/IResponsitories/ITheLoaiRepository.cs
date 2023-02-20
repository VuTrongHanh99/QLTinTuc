using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface ITheLoaiRepository
    {
        public Task<List<TheLoaiEntity>> GetAllAsync();
        public Task<TheLoaiEntity> GetAsync(int id);
        public Task<bool> InsertAsync(TheLoaiEntity model);
        public Task<bool> UpdateAsync(int id, TheLoaiEntity model);
        public Task<bool> DeleteAsync(int id);
    }
}
