using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupplierService.Application.DTOs;
using SupplierService.Application.UseCases;

namespace SupplierService.API.Controllers;

[ApiController]
[Route("deliveries")]
[Authorize]
public class DeliveryController : ControllerBase
{
    private readonly CreateDeliveryUseCase _createUseCase;
    private readonly GetDeliveriesUseCase _getUseCase;

    public DeliveryController(
        CreateDeliveryUseCase createUseCase,
        GetDeliveriesUseCase getUseCase)
    {
        _createUseCase = createUseCase;
        _getUseCase = getUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDeliveryDto dto)
    {
        await _createUseCase.Execute(dto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _getUseCase.Execute();
        return Ok(result);
    }
}