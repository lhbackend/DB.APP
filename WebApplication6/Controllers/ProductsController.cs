using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication6.Controllers
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }

        
        // yazım kurallarına uyarak yazz
    }
    public class ProductsController : ApiController
    {
        private List<Product> products = new List<Product>
     {
        new Product { Id = 1, ProductName = "Product 1", City = "Istanbul", District = "Kadikoy", Price = 10.99m, Stock = 50, Category = "Category X",  },
        new Product { Id = 2, ProductName = "Product 2", City = "Istanbul", District = "Besiktas", Price = 15.99m, Stock = 25, Category = "Category B" },
        new Product { Id = 3, ProductName = "Product 3", City = "Ankara", District = "Cankaya", Price = 25.99m, Stock = 100, Category = "Category A" },
        new Product { Id = 4, ProductName = "Product 4", City = "Ankara", District = "Kecioren", Price = 8.99m, Stock = 75, Category = "Category C" },
        new Product { Id = 5, ProductName = "Product 5", City = "Izmir", District = "Bornova", Price = 12.99m, Stock = 60, Category = "Category B" },
        new Product { Id = 6, ProductName = "Product 6", City = "Izmir", District = "Konak", Price = 9.99m, Stock = 35, Category = "Category A" },
        new Product { Id = 7, ProductName = "Product 7", City = "Bursa", District = "Osmangazi", Price = 18.99m, Stock = 80, Category = "Category C", },
        new Product { Id = 8, ProductName = "Product 8", City = "Bursa", District = "Nilufer", Price = 7.99m, Stock = 65, Category = "Category B" },
        new Product { Id = 9, ProductName = "Product 9", City = "Antalya", District = "Muratpasa", Price = 14.99m, Stock = 45, Category = "Category A" },
        new Product { Id = 10, ProductName = "Product 10", City = "Antalya", District = "Konyaalti", Price = 22.99m, Stock = 55, Category = "Category C" }
     };
        // GET api/products
        public IEnumerable<Product> Get()
        {
            return products;
        }

        // GET api/products/city/{city}
        [Route("api/products/city/{city}")]
        public IEnumerable<Product> GetByCity(string city)
        {
            return products.Where(p => p.City.ToLower() == city.ToLower());
        }

        // GET api/products/city/{city}/district/{district}
        [Route("api/products/city/{city}/district/{district}")]
        public IEnumerable<Product> GetByCityAndDistrict(string city, string district)
        {
            return products.Where(p => p.City.ToLower() == city.ToLower() && p.District.ToLower() == district.ToLower());
        }

        // GET api/products/category/{category}
        [Route("api/products/category/{category}")]
        public IEnumerable<Product> GetByCategory(string category)
        {
            return products.Where(p => p.Category.ToLower() == category.ToLower());
        }

        // POST api/products
        public HttpResponseMessage Post([FromBody] Product product)
        {
            products.Add(product);

            var response = Request.CreateResponse(HttpStatusCode.Created, product);
            response.Headers.Location = new Uri(Request.RequestUri + "/" + product.Id);

            return response;
        }

        

    }



}

