using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cornershop.Transfer;

namespace Cornershop.Models
{
    public partial class tienda
    {
        public static tiendaDT registrarTienda(tiendaDT tienda)
        {
            cornershopEntities db = new cornershopEntities();
            Random random = new Random();
            string codigo = random.Next(100000, 999999).ToString();
            string contador = db.tiendas.Count().ToString();
            db.tiendas.Add(new tienda
            {
                cod_tie = "T" + contador,
                nom_tie = tienda.nomTienda,
                dir_tie = tienda.dirTienda,
                telefono = tienda.telefono,
                celular = tienda.celular,
                cod_dis = tienda.codDis,
                id_cat_tienda = tienda.idCatTienda,
                cod_usu_tienda = tienda.codUsuTienda,
                id_pais_tienda=tienda.idPaisTienda
            });
            db.SaveChanges();

            var e = (from p in db.usuarios
                     where p.cod_usu == tienda.codUsuTienda
                     select p).FirstOrDefault<usuario>();
            if (e!=null)
            {
                tiendaDT obj = new tiendaDT();
                verificacionCorner email = new verificacionCorner();
                email.enviarVerificacionTienda(e.correo, tienda);
                obj = tienda;
                return obj;
            }
            else
            {
                tiendaDT obj = new tiendaDT();
                obj.codUsuTienda = "No existe usuario";
                return obj;
            }
        }
        public static List<tiendaListaDT> listarTienda(String codUsuario)
        {
            cornershopEntities db = new cornershopEntities();
            return (from a in db.tiendas
                          join h in db.CATEGORIA_TIENDA
                            on a.id_cat_tienda equals h.ID_CATEGORIA
                          join s in db.PAIS
                            on a.id_pais_tienda equals s.ID_PAIS
                          join u in db.usuarios
                              on a.cod_usu_tienda equals u.cod_usu
                          where u.cod_usu == codUsuario
                          select new tiendaListaDT 
                          {
                              //asesor = a.nombres+' '+ a.apellidos
                              nomTienda = a.nom_tie,
                              dirTienda = a.dir_tie,
                              telefono = a.telefono,
                              celular = a.celular,
                              tCategoria = h.C_NOMBRE,
                              tPais = s.C_NOMBRE
                          }).ToList();
        }
    }
}