using AutoMapper;
using Challenge.Api.Request.DTOs;
using Challenge.Api.Request.DTOs.Erros;
using Challenge.Api.Request.Validation;
using Challenge.Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Api.Controllers
{

	[Produces("application/json")]
	[ApiController]
	[Route("[controller]")]
	public class ProductsController : ControllerBase
	{
		public readonly IProductService _productService;

		private readonly IMapper _mapper;

		private readonly IValidator<ProductFilterDTO> _validatorFilter;

		private readonly IValidator<ProductDTO> _validatorProd;

		private readonly IValidator<ProductInsertDTO> _validatorProdInsert;


		public ProductsController(IProductService productService, 
								  IMapper mapper,
								  IValidator<ProductFilterDTO> validatorFilter, 
								  IValidator<ProductDTO> validatorProd,
								  IValidator<ProductInsertDTO> validatorProdInsert)
		{
			_productService = productService;
			_mapper = mapper;
			_validatorFilter = validatorFilter;
			_validatorProd = validatorProd;
			_validatorProdInsert = validatorProdInsert;
		}

		/// <summary>
		/// Realiza uma operação de seleção em produtos com base nos critérios fornecidos.
		/// </summary>
		/// <param name="request">Um objeto ProductFilterDTO que contém os critérios de seleção.</param>
		/// <returns>
		/// Retorna um status 200 OK com uma lista de produtos se a solicitação for válida e a operação for bem-sucedida.
		/// Retorna um status 400 Bad Request com uma lista de erros se a solicitação não for válida.
		/// </returns>
		/// <response code="200">Retorna a lista de produtos</response>
		/// <response code="204">Nenhum registro encontrado</response>
		/// <response code="400">Se a validação falhar</response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDTO>))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<ValidationErrorsDTO>))]
		public IActionResult Select([FromBody] ProductFilterDTO request)
		{
			var validationResult = _validatorFilter.Validate(request);
			if (!validationResult.IsValid)
			{
				var errors = validationResult.Errors.Select(error => new ValidationErrorsDTO
				{
					propertyName = error.PropertyName,
					errorMessage = error.ErrorMessage
				});

				return BadRequest(errors);
			}
			var products = _productService.Select(request);
			var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
			return productDTOs.Any() ? Ok(productDTOs) : NoContent();
		}

		/// <summary>
		/// Realiza uma operação para criar um produto.
		/// </summary>
		/// <param name="request">Um objeto ProductInsertDTO</param>
		/// <returns>
		/// Retorna um status 201 se a operação for bem-sucedida.
		/// Retorna um status 400 Bad Request com uma lista de erros se a solicitação não for válida.
		/// Retorna um status 500 Bad Request se ocorrer um erro interno.
		/// </returns>
		/// <response code="201">Inserido com sucesso</response>
		/// <response code="400">Se a validação falhar</response>
		/// <response code="500">Erro interno</response>
		[HttpPost("Create")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<ValidationErrorsDTO>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Create([FromBody] ProductInsertDTO request)
		{
			var validationResult = _validatorProdInsert.Validate(request);
			if (!validationResult.IsValid)
			{
				var errors = validationResult.Errors.Select(error => new ValidationErrorsDTO
				{
					propertyName = error.PropertyName,
					errorMessage = error.ErrorMessage
				});

				return BadRequest(errors);
			}
			_productService.Insert(request);
			return NoContent();
		}


		/// <summary>
		/// Realiza uma operação para atualizar um produto.
		/// </summary>
		/// <param name="request">Um objeto ProductDTO</param>
		/// <returns>
		/// Retorna um status 201 se a operação for bem-sucedida.
		/// Retorna um status 400 Bad Request com uma lista de erros se a solicitação não for válida.
		/// Retorna um status 500 Bad Request se ocorrer um erro interno.
		/// </returns>
		/// <response code="201">Atualizado com sucesso</response>
		/// <response code="400">Se a validação falhar</response>
		/// <response code="500">Erro interno</response>
		[HttpPatch("Update")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<ValidationErrorsDTO>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Update([FromBody] ProductDTO request)
		{
			var validationResult = _validatorProd.Validate(request);
			if (!validationResult.IsValid)
			{
				var errors = validationResult.Errors.Select(error => new ValidationErrorsDTO
				{
					propertyName = error.PropertyName,
					errorMessage = error.ErrorMessage
				});

				return BadRequest(errors);
			}
			_productService.Update(request);
			return NoContent();
		}


		/// <summary>
		/// Obtém um produto pelo seu ID.
		/// </summary>
		/// <param name="id">ID do produto a ser obtido.</param>
		/// <returns>
		/// Retorna o produto correspondente ao ID especificado.
		/// Retorna um status 404 Not Found se o produto não for encontrado.
		/// </returns>
		/// <response code="200">Retorna o produto correspondente ao ID.</response>
		/// <response code="404">Se o produto não for encontrado.</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
		public IActionResult GetById(int id)
		{
			var product = _productService.Select(id);

			if (product == null)
			{
				return BadRequest("Nenhum produto encontrato");
			}

			return Ok(product);
		}


		/// <summary>
		/// Remove um produto pelo seu ID.
		/// </summary>
		/// <param name="id">ID do produto a ser removido.</param>
		/// <returns>
		/// Retorna um status 204 No Content se o produto for removido com sucesso.
		/// Retorna um status 404 Not Found se o produto não for encontrado.
		/// Retorna um status 500 Internal Server Error se ocorrer um erro interno.
		/// </returns>
		/// <response code="204">Produto removido com sucesso.</response>
		/// <response code="500">Erro interno.</response>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult DeleteById(int id)
		{
			
			_productService.Delete(id);
			return NoContent();
		
		}

	}
}
