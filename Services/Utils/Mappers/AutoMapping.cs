
using AutoMapper;
using Models.Entities;
using Services.ViewModels;
using SistemaGestion;
using SistemaGestion.Utils;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Producto, ProductoViewModel>().ReverseMap();
        CreateMap<ClienteProveedor, ClienteProveedorViewModel>().ReverseMap();
        CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
        CreateMap<SubCategoria, SubCategoriaViewModel>().ReverseMap();
    }
}

