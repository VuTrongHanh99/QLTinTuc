using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.IResponsitories
{
    public interface IMenuMainRepository
    {
        public Task<List<MenuMainEntity>> GetAllAsync();
        public Task<MenuMainEntity> GetAsync(int id);
        public Task<bool> InsertAsync(MenuMainEntity model);
        public Task<bool> UpdateAsync(int id, MenuMainEntity model);
        public Task<bool> DeleteAsync(int id);
        #region 
        public Task<List<MenuMainEntity>> GetMenuMainAsync(int parentId);
        #endregion
    }
}
