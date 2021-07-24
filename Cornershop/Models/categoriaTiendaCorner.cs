using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cornershop.Transfer;

namespace Cornershop.Models
{
    public partial class categoriaTienda
    {
        public  static List<categoriaTiendaDT> listar()
        {
            cornershopEntities db = new cornershopEntities();
            var cateTienda = db.CATEGORIA_TIENDA.Select(c=>new categoriaTiendaDT { 
            idCategoria = c.ID_CATEGORIA,
            cNombre = c.C_NOMBRE
            }).ToList();
            return cateTienda;
        }
    }
}