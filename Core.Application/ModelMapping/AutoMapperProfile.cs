using AutoMapper;
using Core.Domain.Entities;
using Data.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.ModelMapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //map 2 đảo chiều sử dụng các tên view tương đương
            CreateMap<TheLoai, TheLoaiEntity>().ReverseMap();
        }
    }
}
