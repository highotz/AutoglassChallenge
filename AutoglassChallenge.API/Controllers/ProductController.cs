﻿using AutoglassChallenge.API.Models.Errors;
using AutoglassChallenge.Application.HttpHandlers.Product;
using AutoglassChallenge.Application.Interfaces;
using AutoglassChallenge.Domain.DTOs;
using AutoglassChallenge.Domain.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AutoglassChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,
            IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }

        /// <summary>
        /// Create product
        /// </summary>
        /// <param name="productRequest">Model to create product</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductRequest productRequest)
        {
            try
            {
                if (productRequest is null)
                {
                    return Ok();
                }

                var productDto = _mapper.Map<ProductDto>(productRequest);
                await _productService.Create(productDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BuildError(ex);
            }

        }

        /// <summary>
        /// Update produt
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <param name="productRequest">Model to update produt</param>
        [HttpPut("{productId}")]
        public async Task<IActionResult> Update(int productId, [FromBody] ProductRequest productRequest)
        {
            try
            {
                if (productRequest != null)
                {
                    var productDto = _mapper.Map<ProductDto>(productRequest);
                    productDto.Id = productId;
                    await _productService.Update(productDto);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BuildError(ex);
            }

        }

        /// <summary>
        /// Inactive a product by id
        /// </summary>
        /// <param name="productId">Product id</param>
        [HttpDelete("{productId}")]
        public async Task Delete([FromRoute] int productId)
        {
            await _productService.Delete(productId);
        }

        /// <summary>
        /// Get products by filter and paginated
        /// </summary>
        /// <param name="productFilter">Model to filter products</param>
        [HttpGet]
        public async Task<PaginatedDto<ProductResponse>> GetByFilterPaginated([FromQuery] ProductFilter productFilter)
        {
            var products = await _productService.GetByFilterPaginated(productFilter);
            return new PaginatedDto<ProductResponse>()
            {
                Items = products.Items.Select(x => _mapper.Map<ProductResponse>(x)),
                ItemsByPage = products.ItemsByPage,
                PageIndex = products.PageIndex,
                TotalItems = products.TotalItems,
            };
        }

        /// <summary>
        /// Get produt by id
        /// </summary>
        /// <param name="productId">Id from product</param>
        [HttpGet("{productId}")]
        public async Task<ProductResponse> GetById([FromRoute] int productId)
        {
            var product = await _productService.GetById(productId);

            if (product is null)
            {
                return default;
            }

            return _mapper.Map<ProductResponse>(product);
        }

        private ObjectResult BuildError(Exception ex)
        {
            return BadRequest(new ErrorResponse()
            {
                Code = "Dados invalidos",
                Message = ex.Message
            });
        }
    }
}
