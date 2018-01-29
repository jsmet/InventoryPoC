using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("[action]")]
        public Products GetProducts()
        {
            return new Products()
            {
                Name = "Immortality Serum",
                Description = "Live long time"
            };
        }

        [HttpGet("[action]")]
        public IEnumerable<ProductTypes> GetProductTypes()
        {
            List<ProductTypes> result = new List<ProductTypes>();

            result.Add(new ProductTypes() { Name = "Music", Icon = "glyphicon-music" });
            result.Add(new ProductTypes() { Name = "Glass", Icon = "glyphicon-glass" });
            result.Add(new ProductTypes() { Name = "Grass", Icon = "glyphicon-grain" });

            return result;
        }

        [HttpGet("[action]")]
        public IEnumerable<Item> GetItems([FromQuery]string productName)
        {
            FakeRepo repo = new FakeRepo();

            return repo.GetItems(productName);
        }
    }

    public class ProductTypes
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }

    public class Products
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public int QuantityOnHand { get; set; }
        public string ExpirationDate { get; set; }
    }

    public class FakeRepo
    {
        public List<Item>GetItems(string productName)
        {
            List<Item> result = new List<Item>();

            switch (productName)
            {
                case "Music":
                    result.Add(new Item()
                    {
                        Name = "Steve Miller Band",
                        Description = "The good stuff",
                        Cost = "14.99",
                        QuantityOnHand = 5,
                        ExpirationDate = "12/31/2999"
                    });
                    result.Add(new Item()
                    {
                        Name = "Nelly",
                        Description = "He's kewl",
                        Cost = "10.99",
                        QuantityOnHand = 2,
                        ExpirationDate = "12/31/1999"
                    });
                    result.Add(new Item()
                    {
                        Name = "Lostprophets",
                        Description = "Your modern day classic",
                        Cost = "19.99",
                        QuantityOnHand = 1,
                        ExpirationDate = "12/31/2099"
                    });
                    break;
                case "Glass":
                    result.Add(new Item()
                    {
                        Name = "Rock glass",
                        Description = "The only glass you need",
                        Cost = "9.99",
                        QuantityOnHand = 99,
                        ExpirationDate = string.Empty
                    });
                    result.Add(new Item()
                    {
                        Name = "Wine glass",
                        Description = "An argument could be made that this glass is also a necessity",
                        Cost = "14.99",
                        QuantityOnHand = 0,
                        ExpirationDate = string.Empty
                    });
                    result.Add(new Item()
                    {
                        Name = "Water glass",
                        Description = "It says water glass, just don't smell the contents",
                        Cost = "5.99",
                        QuantityOnHand = 5,
                        ExpirationDate = string.Empty
                    });
                    break;
                case "Grass":
                    result.Add(new Item()
                    {
                        Name = "Wheat grass",
                        Description = "Will probably make you sneeze",
                        Cost = "14.99",
                        QuantityOnHand = 5,
                        ExpirationDate = "12/31/2001"
                    });
                    result.Add(new Item()
                    {
                        Name = "Kentucky blue grass",
                        Description = "Is it really blue?",
                        Cost = "14.99",
                        QuantityOnHand = 5,
                        ExpirationDate = "12/31/2999"
                    });
                    result.Add(new Item()
                    {
                        Name = "Dead grass",
                        Description = "It's dead",
                        Cost = "14.99",
                        QuantityOnHand = 5,
                        ExpirationDate = "12/31/2999"
                    });
                    break;
            }

            return result;
        }
    }
}