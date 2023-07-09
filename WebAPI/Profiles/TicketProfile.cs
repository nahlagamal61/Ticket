namespace WebAPI.Profiles
{
    using AutoMapper;
    using Domains.Entities;
    using Domains.Enums;
    using WebAPI.DTOS;

    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>().ReverseMap();

            CreateMap<Ticket, TickerResDTO>()
                .ForMember(dest => dest.GovernorateName, opt => opt.MapFrom(src => Enum.GetName(typeof(Governorate), src.Governorate)))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => Enum.GetName(typeof(City), src.City)));
                //.ForMember(dest => dest.TicketStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(TicketStatus), src.TicketStatus)));

        }

    }
}
