using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaGtMotive.Application.Users.GetUsers;
using PruebaGtMotive.Application.Users.RegisterUser;

namespace PruebaGtMotive.Api.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public UsersController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet("GetUsers")]
        [ProducesResponseType(typeof(IReadOnlyList<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();
            var resultados = await _sender.Send(query, cancellationToken);
            return Ok(resultados.Value);
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]  // Para respuesta exitosa
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]  // Para errores
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var command = new RegisterUserCommand(request.Email, request.Nombre, request.Appelidos, request.Password);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
    }
}