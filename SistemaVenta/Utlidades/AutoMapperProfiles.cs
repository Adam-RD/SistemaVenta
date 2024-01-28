using AutoMapper;
using SistemaVenta.Model;

namespace SistemaVenta.Utlidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ReparacionDTO, Reparacion>();
            CreateMap<Reparacion, ReparacionDTO>();

        }
    }
}
