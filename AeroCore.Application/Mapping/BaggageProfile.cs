using AeroCore.Application.Dtos.BaggageDto;
using AeroCore.Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Mapping
{
    public class BaggageProfile : Profile
    {
        public BaggageProfile()
        {
            CreateMap<Baggage, ResponseBaggageDto>();
            CreateMap<CreateBaggageDto, Baggage>();
            CreateMap<UpdateBaggageDto, Baggage>(); 
        }
    }
}
