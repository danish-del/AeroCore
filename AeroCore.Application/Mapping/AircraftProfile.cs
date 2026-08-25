using AeroCore.Application.Dtos.AircraftDto;
using AeroCore.Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Mapping
{
    public class AircraftProfile : Profile
    {
        public AircraftProfile()
        {
            CreateMap<Aircraft, ResponseAircraftDto>();
            CreateMap<CreateAircraftDto, Aircraft>();
            CreateMap<UpdateAircraftDto, Aircraft>();
        }
    }
}
