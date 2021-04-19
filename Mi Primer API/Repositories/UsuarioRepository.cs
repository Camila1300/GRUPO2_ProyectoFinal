using System;
using System.Collections.Generic;
using System.Linq;
using Mi_Primer_API;
using Mi_Primer_API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mi_Primer_API
{
    public class UsuarioRepository
    {
        private readonly Tiendas2Context _context;

        public UsuarioRepository()
        {
            _context = new Tiendas2Context();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario ObtenerUsuario(string email)
        {
            return _context.Usuarios.Where(x => x.Correo == email).FirstOrDefault();
        }

        public async Task<Usuario> Login (Usuario nUsuario)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(x => x.Correo == nUsuario.Correo && x.Contraseña == nUsuario.Contraseña);
            return usuario;
        }
        public async Task<Usuario> Register(Usuario nUsuario)
        {            
            _context.Usuarios.Add(nUsuario);
            await _context.SaveChangesAsync();
            return nUsuario;
        }
        public Usuario Edit(string correo, Usuario nUsuario)
        {
            var usuario = _context.Usuarios.Where(x => x.Correo == correo).FirstOrDefault();
            if(usuario == null)
            {
                return null;
            }
            else
            {
                usuario.NombreUsuario = nUsuario.NombreUsuario;
                usuario.Contraseña = nUsuario.Contraseña;
                //_context.Entry(nUsuario).State = EntityState.Modified;
                _context.SaveChanges();
                return nUsuario;
            }
        }
        public async Task<Usuario> Delete(string correo)
        {
            var usuario = _context.Usuarios.Where(x => x.Correo == correo).FirstOrDefault();
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return usuario;
        }
    }
}