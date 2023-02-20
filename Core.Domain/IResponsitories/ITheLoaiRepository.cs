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
        public Task<List<TheLoaiEntity>> GetAllBooksAsync();
        public Task<TheLoaiEntity> GetBookAsync(int id);
        public Task<int> AddBookAsync(TheLoaiEntity model);
        public Task UpdateBookAsync(int id, TheLoaiEntity model);
        public Task DeleteBookAsync(int id);
    }
}
