
using AutoMapper;
using Models.Entities;
using SistemaGestion;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Producto, ProductoViewModel>().ReverseMap();

        //CreateMap<List<Producto>, List<ProductoViewModel>>();
    }
}

