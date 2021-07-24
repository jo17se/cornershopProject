using Cornershop.Models;
using Cornershop.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cornershop.Controllers
{
    public class usuarioController : ApiController
    {
        /*[HttpGet]
        [Route("api/mail/verificacion")]
        public bool verificacionemail(String destino, String codigo)
        {
            return verificacionCorner.enviarVerificacion(destino,codigo);
        }*/

        [HttpGet]
        [Route("api/usuario/loginUsuario")]
        public userDT login(String correo, String password)
        {
            return usuario.login(correo,password);
        }

        [HttpGet]
        [Route("api/usuario/registroUsuario")]
        public userDT registro(String nomusu,String apellido,String correo, String password)
        {
            userDT usu = new userDT();
            usu.nomusu = nomusu;
            usu.apellido = apellido;
            usu.correo = correo;
            usu.password = password;
            return usuario.registrarUsuario(usu);
        }

        [HttpGet]
        [Route("api/usuario/obtenerUsuario")]
        public userDT obtenerUsuario(String correo)
        {
            return usuario.obtenerUsuario(correo);
        }

        [HttpGet]
        [Route("api/usuario/verificarPerfil")]
        public bool verificarperfil(String id)
        {
            return usuario.verificarperfil(id);
        }

        
    }
}
