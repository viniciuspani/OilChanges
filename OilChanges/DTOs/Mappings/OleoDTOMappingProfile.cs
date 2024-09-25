using AutoMapper;
using OilChanges.Shared.DTOs;
using OilChanges.Shared.Model;

namespace OilChanges.DTOs.Mappings
{
    public class OleoDTOMappingProfile : Profile
    {
        public OleoDTOMappingProfile()
        {
            CreateMap<Oleo, OleoDTO>().ReverseMap();
        }
    }
}
