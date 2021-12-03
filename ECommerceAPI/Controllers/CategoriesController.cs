using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceAPI.Dto.Request;
using ECommerceAPI.Dto.Response;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryDtoCollectionResponse _categories;

        public CategoriesController(CategoryDtoCollectionResponse categories)
        {
            _categories = categories;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            _categories.Success = true;
            return Ok(_categories);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCategories(string id)
        {
            var response = new BaseResponse<CategoryDto>();

            _categories.Success = true;
            var find = _categories.Collection.FirstOrDefault(p => p.Id == id);

            if (find == null)
            {
                return NotFound(response);
            }

            response.Success = true;
            response.Result = find;
            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostCategories([FromBody] CategoryRequest request)
        {
            var response = new BaseResponse<string>();
            var category = new CategoryDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Description = request.Description
            };

            response.Success = true;
            response.Result = category.Id;

            _categories.Collection.Add(category);
            return CreatedAtAction("GetCategories", new
            {
                id = response.Result
            }, response);
        }

        [HttpPut]
        [Route(template: "{id}")]
        public IActionResult PutCategories(string id, [FromBody] CategoryRequest request)
        {
            var response = new BaseResponse<string>();
            var find = _categories.Collection.FirstOrDefault(p => p.Id == id);


            if (find == null)
            {
                return NotFound(response);
            }

            find.Description = request.Description;
            find.Name = request.Name;
            response.Success = true;
            response.Result = id;

            return Ok(response);

        }

        [HttpDelete]
        [Route(template: "{id}")]
        public IActionResult DeleteCategories(string id)
        {
            var response = new BaseResponse<string>();
            var find = _categories.Collection.FirstOrDefault(p => p.Id == id);

            if (find == null)
            {
                return NotFound(response);
            }

            _categories.Collection.Remove(find);
            response.Success = true;
            response.Result = id;

            return Ok(response);

        }
    }
}
