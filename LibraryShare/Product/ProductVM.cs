using System.Collections.Generic;
using LibraryShare.Image;

namespace LibraryShare.Product
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string pathImage { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public int Rated { get; set; }
        public List<ImageVM> Images { get; set; }
        public string CategoryName { get; set; }
        public bool isDelete { get; set; }

    }
}