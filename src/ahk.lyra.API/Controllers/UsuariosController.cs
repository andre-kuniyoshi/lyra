using ahk.lyra.API.DTOs.Requests;
using ahk.lyra.Application.Notification;
using ahk.lyra.Domain.Entities;
using ahk.lyra.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ahk.lyra.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : MainController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService, IMapper mapper, INotifier notifier) : base(mapper, notifier)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Cadastrar([FromBody] CadastroUsuarioRequestDTO usuarioRequestDTO)
        {
            try
            {
                if (usuarioRequestDTO == null || !ModelState.IsValid)
                    return CustomBadRequestResponse(ModelState);

                var usuario = Mapper.Map<Usuario>(usuarioRequestDTO);

                await _usuarioService.AdicionaUsuario(usuario);

                return HasError()
                    ? CustomResponse()
                    : Created(nameof(Cadastrar), usuario);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
            
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditarUsuario([FromBody] CadastroUsuarioRequestDTO request, Guid id)
        {
            try
            {
                if (request == null || !ModelState.IsValid)
                    return CustomBadRequestResponse(ModelState);

                var usuarioAtualizado = Mapper.Map<Usuario>(request);

                var resultado = await _usuarioService.AtualizaUsuario(id, usuarioAtualizado);

                return CustomResponse(resultado);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
            
        }

        [HttpGet("Completo/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarUsuarioCompleto(Guid id)
        {
            try
            {
                var usuario = await _usuarioService.BuscaUsuarioPorID(id);

                return usuario is not null ? Ok(usuario) : NotFound();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarTodosUsuario()
        {
            try
            {
                var usuarios = await _usuarioService.BuscaTodosUsuarios();

                return CustomResponse(usuarios);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
            
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletarUsuario(Guid id)
        {
            try
            {
                var result = await _usuarioService.DeletaUsuario(id);

                return CustomResponse(id);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }
    }
}
