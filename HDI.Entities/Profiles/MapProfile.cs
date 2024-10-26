using AutoMapper;
using HDI.Entities.DTOs;
using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Entities
{
    /// <summary>
    /// AutoMapper map profile...
    /// </summary>
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Partner, PartnerModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Contract, ContractModel>().ReverseMap();
            CreateMap<Work, WorkModel>().ReverseMap();
        }
    }
}
