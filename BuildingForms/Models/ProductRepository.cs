using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingForms.Models
{
    public static class ProductRepository
    {
        private static List<Product> _products;

        static ProductRepository()   /* ctor oluşturarak elimizde bir kaç veri olsun */
        {
            _products = new List<Product>()  /* Elemenları direkt bunun içerisine ekleyelim. */
            {
                new Product(){Id=1,Name="Product 1",Description="Description 1",Price=10,IsApproved=true},
                new Product(){Id=2,Name="Product 2",Description="Description 2",Price=20,IsApproved=true},
                new Product(){Id=3,Name="Product 3",Description="Description 3",Price=30,IsApproved=false},
                new Product(){Id=4,Name="Product 4",Description="Description 4",Price=140,IsApproved=true},
                new Product(){Id=5,Name="Product 5",Description="Description 5",Price=50,IsApproved=false},
                new Product(){Id=6,Name="Product 6",Description="Description 6",Price=16,IsApproved=true}
            };
        }

        public static List<Product> Products 
        {
          get { return _products; }   /* Okunabilir _products ı bana geri gönderebilsin */
        }
        public static void AddProduct(Product entity)    /* static bir ekleme olsun ama void yaparak geri dönüşü de olmasın */
       /* Dışardan bir Product nesnesi alsın aldığı bu dışardan nesneye de entity diyelim*/
        {
            _products.Add(entity);  /* _products listesinin üzerine entity i ekleyelim */
        }                                                  
    }
}
