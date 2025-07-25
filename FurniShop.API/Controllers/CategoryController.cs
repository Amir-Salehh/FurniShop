using AutoMapper;
using FurniShop.Application.DTOs.Product;
using FurniShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Security;
using System.Threading.Tasks;

namespace FurniShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        #region Get All Category
        [HttpGet("Categories")]
        public IActionResult GetAll() 
        {
            var categories = _categoryService.GetAll();
            if (categories == null)
            {
                return NotFound("دسته بندی وجود ندارد");
            }
            var categoryDto = _mapper.Map<List<CategoryResponseDto>>(categories);

            return Ok(categoryDto);
        }
        #endregion

        #region Create Category
        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _categoryService.CheckExistCategoryByName(request.CategoryName))
            {
                return BadRequest("دسته بندی وجود دارد");
            }

            await _categoryService.CreateCategory(request);
            return Ok("دسته بندی ساخته شد");
        }
        #endregion

        #region Update Category
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id,[FromBody] CategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(! await _categoryService.CheckExistCategoryById(id))
            {
                return BadRequest("این دسته بندی وجود ندارد");
            }

            await _categoryService.UpdateCategory(id, request.CategoryName);

            return Ok("دسته بندی آپدیت شد");
        }
        #endregion

        #region Delete Category
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!await _categoryService.CheckExistCategoryById(id))
            {
                return BadRequest("این دسته وجود ندارد");
            }
            await _categoryService.DeleteCategory(id);

            return Ok("دسته بندی حذف شد");
        }
        #endregion

    }
}
