using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Api.Controllers.Alquileres;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaGtMotive.Application.Alquileres.CompletarAlquiler;
using PruebaGtMotive.Application.Alquileres.CreateAlquiler;

namespace PruebaGtMotive.Api.Controllers.Alquileres;

[ApiController]
[Route("api/[controller]")]
public class AlquileresController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AlquileresController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }




    [HttpPost("CreateAlquiler")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]  // Para respuesta exitosa
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]  // Para errores
    public async Task<IActionResult> CreateAlquiler(CreateAlquilerRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateAlquilerCommand>(request);

        var resultado = await _sender.Send(command, cancellationToken);

        if(resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(nameof(CreateAlquiler), new {id = resultado.Value}, resultado.Value);
    }

    
    [HttpPost("EntregarVehiculo")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]  // Para respuesta exitosa
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]  // Para errores
    public async Task<IActionResult> EntregarVehiculo(CompletarAlquilerRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CompletarAlquilerCommand>(request);

        var resultado = await _sender.Send(command, cancellationToken);

        if(resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(nameof(EntregarVehiculo), new {id = resultado.Value}, resultado.Value);
    }

}
