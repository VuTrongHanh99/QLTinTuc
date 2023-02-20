using AutoMapper;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
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
    public class TheLoaiRepository : ITheLoaiRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TheLoaiRepository> _logger;

        public TheLoaiRepository(DataContext context, IMapper mapper, ILogger<TheLoaiRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> InsertAsync(TheLoaiEntity model)
        {
            bool data = false;
            try
            {
                var newBook = _mapper.Map<TheLoai>(model);
                _context.TheLoais!.Add(newBook);
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
        public async Task<bool> UpdateAsync(int id, TheLoaiEntity model)
        {
            bool data = false;
            try
            {
                if (id == model.CategoryId)
                {
                    var updateBook = _mapper.Map<TheLoai>(model);
                    _context.TheLoais!.Update(updateBook);
                    var check=await _context.SaveChangesAsync();
                    if(check>0)
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
                var del = _context.TheLoais!.SingleOrDefault(b => b.CategoryId == id);
                if (del != null)
                {
                    _context.TheLoais!.Remove(del);
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
        public async Task<List<TheLoaiEntity>> GetAllAsync()
        {
            var data = new List<TheLoaiEntity>();
            try
            {
                var result = await _context.TheLoais!.ToListAsync();
                data = _mapper.Map<List<TheLoaiEntity>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return data;
        }
        public async Task<TheLoaiEntity> GetAsync(int id)
        {
            var data=new TheLoaiEntity();
            try
            {
                var result = await _context.TheLoais!.FindAsync(id);
                data= _mapper.Map<TheLoaiEntity>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return data; 
        }
    }
}
