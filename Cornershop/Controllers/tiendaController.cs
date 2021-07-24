using Cornershop.Models;
using Cornershop.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cornershop.Models;

namespace Cornershop.Controllers
{
    public class tiendaController : ApiController
    {
        // GET: Tienda
        [HttpPost]
        [Route("api/tienda/registroTienda")]
        public tiendaDT registro(tiendaDT tiendao)
        {
            return tienda.registrarTienda(tiendao);
        }

        [HttpGet]
        [Route("api/tienda/listar")]
        public List<tiendaListaDT> listar(String codUsuario)
        {
            return tienda.listarTienda(codUsuario);
        }
    }
}
