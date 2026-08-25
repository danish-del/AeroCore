using AeroCore.Application.Dtos.AirportDto;
using AeroCore.Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Mapping
{
    public class AirportProfile : Profile
    {
        public AirportProfile()
        {
            CreateMap<Airport, ResponseAirportDto>();
            CreateMap<UpdateAirportDto, Airport>();
            CreateMap<ResponseAirportDto, Airport>();
        }
    }
}
