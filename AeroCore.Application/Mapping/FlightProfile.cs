using AeroCore.Application.Dtos.FlightDto;
using AeroCore.Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Mapping
{
    public  class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, ResponseFlightDto>();
            CreateMap<CreateFlightDto, Flight>();
            CreateMap<UpdateFlightDto, Flight>();
        }
    }
}
