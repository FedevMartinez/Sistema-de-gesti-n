
using AutoMapper;
using Models.Entities;
using Sistema_de_gestión;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Producto, ProductoViewModel>();

        CreateMap<List<Producto>, List<ProductoViewModel>>();
    }
}

