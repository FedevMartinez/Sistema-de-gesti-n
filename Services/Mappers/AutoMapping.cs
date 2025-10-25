
using AutoMapper;
using Models.Entities;
using SistemaGestion;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Producto, ProductoViewModel>();

        //CreateMap<List<Producto>, List<ProductoViewModel>>();
    }
}

