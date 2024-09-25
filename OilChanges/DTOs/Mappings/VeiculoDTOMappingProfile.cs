using OilChanges.Shared.Model;
using OilChanges.Shared.DTOs;
using AutoMapper;

namespace OilChanges.DTOs.Mappings
{
    public class VeiculoDTOMappingProfile : Profile
    {
        public VeiculoDTOMappingProfile()
        {
            CreateMap<Veiculo, VeiculoDTO>().ReverseMap();
        }
    }
}
