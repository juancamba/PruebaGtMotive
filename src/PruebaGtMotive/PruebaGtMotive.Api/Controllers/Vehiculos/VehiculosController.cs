
using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaGtMotive.Application.Vehiculos.CreateVehiculos;
using PruebaGtMotive.Application.Vehiculos.GetVehiculosDisponibles;

namespace PruebaGtMotive.Api.Controllers.Vehiculos;

[ApiController]

[Route("api/vehiculos")]
public class VehiculosController : ControllerBase
{

    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public VehiculosController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

 
    [ProducesResponseType(typeof(IReadOnlyList<VehiculoResponse>), StatusCodes.Status200OK)]
    [HttpGet("GetVehiculosDisponibles")]
    public async Task<IActionResult> GetVehiculosDisponibles( CancellationToken cancellationToken   )
    {
        var query = new GetVehiculosDisponiblesQuery();
        var resultados = await _sender.Send(query, cancellationToken);
        return Ok(resultados.Value);
    }
    [HttpPost("CreateVehiculo")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateVehiculo(CreateVehiculoRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateVehiculoCommand>(request);

        var resultado = await _sender.Send(command, cancellationToken);

        if(resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(nameof(CreateVehiculo), new {id = resultado.Value}, resultado.Value);
    }

}