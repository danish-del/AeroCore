using AeroCore.Application.Dtos.AirlineDto;
using AeroCore.Domain.Model;
using AutoMapper;


namespace AeroCore.Domain.Model
{
    public class AirlcraftProfile : Profile
    {
        public AirlcraftProfile()
        {
            CreateMap<Airline, ResponseAirlineDto>();
            CreateMap<CreateAirlineDto, Airline>();
            CreateMap<UpdateAirDto, Airline>();
        }
    }
}
