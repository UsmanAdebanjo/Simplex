using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Simplex.Dto;
using Simplex.Models;

namespace Simplex.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Customer, CustomerDto>();
        }
    }
}