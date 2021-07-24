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
    public class paisController : ApiController
    {
        // GET: pais
        [HttpGet]
        [Route("api/pais/listar")]
        public List<paisDT> listar()
        {
            return paisCorner.listar();
        }
    }
}