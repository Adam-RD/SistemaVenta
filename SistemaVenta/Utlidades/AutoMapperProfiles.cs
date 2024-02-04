using AutoMapper;
using SistemaVenta.DTOs;
using SistemaVenta.Model;

namespace SistemaVenta.Utlidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ReparacionDTO, Reparacion>();
            CreateMap<Reparacion, ReparacionDTO>();
            
            CreateMap<ProductoDTO,Producto>();
            CreateMap<Producto, ProductoDTO>();

            CreateMap<CategoriaDTO, Categoria>();
            CreateMap<Categoria, CategoriaDTO>();

        }
    }
}
