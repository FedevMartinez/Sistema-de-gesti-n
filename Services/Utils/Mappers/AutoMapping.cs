
using AutoMapper;
using Models.Entities;
using SistemaGestion;
using SistemaGestion.Utils;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Producto, ProductoViewModel>().ReverseMap();
        CreateMap<ClienteProveedor, ClienteProveedorViewModel>().ReverseMap();

        
        //CreateMap<List<Producto>, List<ProductoViewModel>>();
    }
}

