using System.Collections.Generic;
using backend.Controllers;
using backend.Models;
using Microsoft.AspNetCore.Http;

namespace backend_test.MockData
{
    public class NewData
    {
        public static Product NewProduct() => new Product
        {
            Name = "Test Product Request Name",
            Price = 200,
            Images = new List<Image>()
            {
                new Image{pathImage = "picture1.jpg" },
                new Image{pathImage = "picture2.jpg"},
                new Image{pathImage = "picture3.jpg"},
            }
        };
        public static ProductRequest CreateProduct() => new ProductRequest
        {
            Name = "Test Product Request Name",
            CategoryId = 1,
            Price = 200,
            Images = new List<IFormFile>()
            {
                new FormFile(null,1,1,"picture1.jpg","picture1"),
                new FormFile(null,2,3,"picture3.jpg","picture2"),
                new FormFile(null,2,3,"picture2.jpg","picture3"),
            }
        };

    }
}