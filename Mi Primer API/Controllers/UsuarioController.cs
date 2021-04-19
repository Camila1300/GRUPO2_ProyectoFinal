using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Mi_Primer_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController: ControllerBase
    {
        
        private UsuarioRepository _UsuarioRepository;

        public UsuarioController(){
           _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public List<Usuario> ObtenerListaUsuarios()
        {
            return _UsuarioRepository.ObtenerUsuarios();
        }

        [HttpGet("{correo}")]
        public Usuario ObtenerUsuario(string correo)
        {
            return _UsuarioRepository.ObtenerUsuario(correo);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> LoginUsuario ([FromBody]Usuario nUsuario)
        {
            var usuario = await _UsuarioRepository.Login(nUsuario);
            if (usuario == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<Usuario>> RegisterUsuario([FromBody]Usuario nUsuario)
        {
            var user = await _UsuarioRepository.Register(nUsuario);
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut("{correo}")]
        public Usuario EditUsuario(string correo, [FromBody]Usuario nUsuario)
        {
            return _UsuarioRepository.Edit(correo, nUsuario);
        }

        [HttpDelete("{correo}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(string correo)
        {
            var usuario = await _UsuarioRepository.Delete(correo);
            if(usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}