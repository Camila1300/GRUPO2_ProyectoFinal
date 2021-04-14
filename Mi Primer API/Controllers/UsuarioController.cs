using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
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
        public Usuario LoginUsuario (string correo, string contraseña)
        {
            return _UsuarioRepository.Login(correo, contraseña);
        }

        [HttpPost("register")]
        public Usuario RegisterUsuario([FromBody]Usuario nUsuario)
        {
            return _UsuarioRepository.Register(nUsuario);
        }

        [HttpPut("{correo}")]
        public Usuario EditUsuario(string correo, [FromBody]Usuario nUsuario)
        {
            return _UsuarioRepository.Edit(correo, nUsuario);
        }

        [HttpDelete("{correo}")]
        public string DeleteUsuario(string correo)
        {
            return _UsuarioRepository.Delete(correo);
        }
    }
}