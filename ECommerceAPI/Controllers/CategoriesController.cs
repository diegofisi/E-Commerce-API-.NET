using ECommerceAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Category 1"
                },
                new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Category 1"
                }
            };
        }
    }
}
