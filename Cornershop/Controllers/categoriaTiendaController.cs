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
    public class categoriaTiendaController : ApiController
    {
        // GET: CategoriaTienda
        [HttpGet]
        [Route("api/categoriaTienda/listar")]
        public List<categoriaTiendaDT> listar()
        {
            return categoriaTienda.listar();
        }
    }
}