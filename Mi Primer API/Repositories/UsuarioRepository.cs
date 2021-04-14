using System.Collections.Generic;
using System.Linq;
using Mi_Primer_API;
using Mi_Primer_API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

        public Usuario Login (string correo, string contraseña)
        {
            var usuario = _context.Usuarios.Where(x => x.Correo == correo).FirstOrDefault();
            if (usuario == null)
            {
                return null;
            }
            else
            {
                if (correo == usuario.Correo && contraseña == usuario.Contraseña)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }
        public Usuario Register(Usuario nUsuario)
        {
            var usuario = _context.Usuarios.Where(x => x.Correo == nUsuario.Correo).FirstOrDefault();
            if(usuario != null)
            {
                return null;
            }
            else
            {
                _context.Usuarios.Add(nUsuario);
                _context.SaveChanges();
                return nUsuario;
            }
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
        public string Delete(string correo)
        {
            var usuario = _context.Usuarios.Where(x => x.Correo == correo).FirstOrDefault();
            if(usuario == null)
            {
                return "El correo no existe";
            }
            else
            {
                _context.Usuarios.Remove(_context.Usuarios.Find(correo));
                _context.SaveChanges();
                return "Usuario borrado, Correo: " + correo;
            }
        }
    }
}