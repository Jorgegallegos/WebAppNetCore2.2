using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppNetCore2._2.Entities;
using WebAppNetCore2._2.Models;

namespace WebAppNetCore2._2.MappingConfigurations
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Developer, DeveloperIndexDTO>();
        }
    }
}
