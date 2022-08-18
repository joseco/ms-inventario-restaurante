using Inventario.Application.Dto;
using Inventario.Application.UseCases.Command.Articulos.CrearArticulo;
using Inventario.Application.UseCases.Query.Articulos.GetArticuloById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IMediator _mediator;
       

        public ArticuloController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearArticuloCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetArticuloByIdQuery(id));

            if (result == null) { return NotFound(); }

            return Ok(result);
        }
    }
}
