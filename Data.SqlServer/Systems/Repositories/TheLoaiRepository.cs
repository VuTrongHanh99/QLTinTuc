using AutoMapper;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Data.SqlServer.Context;
using Data.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
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

        public TheLoaiRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddBookAsync(TheLoaiEntity model)
        {
            var newBook = _mapper.Map<TheLoai>(model);
            _context.TheLoais!.Add(newBook);
            await _context.SaveChangesAsync();

            return newBook.CategoryId;
        }

        public async Task DeleteBookAsync(int id)
        {
            var deleteBook = _context.TheLoais!.SingleOrDefault(b => b.CategoryId == id);
            if (deleteBook != null)
            {
                _context.TheLoais!.Remove(deleteBook);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TheLoaiEntity>> GetAllBooksAsync()
        {
            var books = await _context.TheLoais!.ToListAsync();
            return _mapper.Map<List<TheLoaiEntity>>(books);
        }

        public async Task<TheLoaiEntity> GetBookAsync(int id)
        {
            var book = await _context.TheLoais!.FindAsync(id);
            return _mapper.Map<TheLoaiEntity>(book);
        }

        public async Task UpdateBookAsync(int id, TheLoaiEntity model)
        {
            if (id == model.CategoryId)
            {
                var updateBook = _mapper.Map<TheLoai>(model);
                _context.TheLoais!.Update(updateBook);
                await _context.SaveChangesAsync();
            }
        }
    }
}
