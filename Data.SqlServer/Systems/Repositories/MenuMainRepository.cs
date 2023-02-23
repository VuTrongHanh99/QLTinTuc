using AutoMapper;
using Core.Domain.Entities;
using Core.Domain.IResponsitories;
using Data.SqlServer.Context;
using Data.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Systems.Repositories
{
    public class MenuMainRepository : IMenuMainRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuMainRepository> _logger;

        public MenuMainRepository(DataContext context, IMapper mapper, ILogger<MenuMainRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> InsertAsync(MenuMainEntity model)
        {
            bool data = false;
            try
            {
                var result = _mapper.Map<MenuMain>(model);
                _context.MenuMains!.Add(result);
                var check = await _context.SaveChangesAsync();
                if (check > 0)
                    data = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return data;
        }
        public async Task<bool> UpdateAsync(int id, MenuMainEntity model)
        {
            bool data = false;
            try
            {
                if (id == model.MenuId)
                {
                    var update = _mapper.Map<MenuMain>(model);
                    _context.MenuMains!.Update(update);
                    var check = await _context.SaveChangesAsync();
                    if (check > 0)
                        data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return data;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool data = false;
            try
            {
                var del = _context.MenuMains!.SingleOrDefault(b => b.MenuId == id);
                if (del != null)
                {
                    _context.MenuMains!.Remove(del);
                    var check = await _context.SaveChangesAsync();
                    if (check > 0)
                        data = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return data;
        }
        public async Task<List<MenuMainEntity>> GetAllAsync()
        {
            var data = new List<MenuMainEntity>();
            try
            {
                var result = await _context.MenuMains!.ToListAsync();
                data = _mapper.Map<List<MenuMainEntity>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return data;
        }
        public async Task<MenuMainEntity> GetAsync(int id)
        {
            var data = new MenuMainEntity();
            try
            {
                var result = await _context.MenuMains!.FindAsync(id);
                data = _mapper.Map<MenuMainEntity>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return data;
        }

        public async Task<List<MenuMainEntity>> GetMenuMainAsync(int parentId)
        {
            var data = new List<MenuMainEntity>();
            try
            {
                var result = await _context.MenuMains!.Where(x => x.ParentId == parentId).ToListAsync();
                data = _mapper.Map<List<MenuMainEntity>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return data;
        }
    }
}
