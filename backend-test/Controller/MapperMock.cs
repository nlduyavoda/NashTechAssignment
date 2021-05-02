using AutoMapper;
using backend.Controllers;
using LibraryShare.Product;

namespace backend_test.Controller
{
    public class MapperMock
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductRequest, ProductVM>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}