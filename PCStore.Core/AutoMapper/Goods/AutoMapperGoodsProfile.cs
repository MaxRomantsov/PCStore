using AutoMapper;
using Microsoft.Extensions.Hosting;
using PCStore.Core.DTO_s.Good;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Core.Entities.SIte;

namespace PCStore.Core.AutoMapper.Goods
{
    public class AutoMapperGoodsProfile : Profile
    {
        public AutoMapperGoodsProfile()
        {
            CreateMap<GoodDto, Good>().ReverseMap();
        }
    }
}
