using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupplierService.Application.DTOs;
using SupplierService.Application.UseCases;

namespace SupplierService.API.Controllers;

[ApiController]
[Route("products")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly CreateProductUseCase _createUseCase;

    public ProductController(CreateProductUseCase createUseCase)
    {
        _createUseCase = createUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        await _createUseCase.Execute(dto);
        return Ok();
    }
}