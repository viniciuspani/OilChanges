using AutoMapper;
using OilChanges.Shared.DTOs;
using OilChanges.Shared.Model;

namespace OilChanges.DTOs.Mappings
{
    public class FiltroDTOMappingProfile : Profile
    {
        public FiltroDTOMappingProfile()
        {
            CreateMap<Filtro, FiltroDTO>().ReverseMap();
        }
    }
}
