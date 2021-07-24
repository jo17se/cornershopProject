using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Cornershop.Transfer;

namespace Cornershop.Models
{
    public class paisCorner
    {
        public static List<paisDT> listar()
        {
            cornershopEntities db = new cornershopEntities();
            return db.PAIS.Select(p => new paisDT
            {
                idPais = p.ID_PAIS,
                cNombre = p.C_NOMBRE
            }).ToList();

        }
    }
}