using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupplierService.Application.DTOs;
using SupplierService.Application.UseCases;

namespace SupplierService.API.Controllers;

[ApiController]
[Route("suppliers")]
[Authorize]
public class SupplierController : ControllerBase
{
    private readonly CreateSupplierUseCase _useCase;

    public SupplierController(CreateSupplierUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSupplierDto dto)
    {
        await _useCase.Execute(dto);
        return Ok();
    }
}