
using System;
using System.ComponentModel.DataAnnotations;
namespace Mi_Primer_API.Controllers
    {  
        public class Usuario
        {
            [Key]
            public string Correo {get; set;}
            
            public string Contraseña {get; set;}
            public string NombreUsuario {get; set;}

            public Usuario (string NCorreo, string NContraseña, string NNombreUsuario)
            {
                Correo = NCorreo;
                Contraseña = NContraseña;
                NombreUsuario = NNombreUsuario;
            }
            public Usuario()
            {

            }
        }
    }