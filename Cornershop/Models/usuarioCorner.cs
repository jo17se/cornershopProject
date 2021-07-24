using Cornershop.Transfer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
namespace Cornershop.Models
{
    public partial class usuario
    {
        public static userDT login(string correo, string contrasenia)
        {
            cornershopEntities db = new cornershopEntities();

            var e = (from p in db.usuarios
                     where p.correo == correo && p.password == contrasenia
                     select p).Any();
            if (e)
            {
                userDT obj = new userDT();
                obj = obtenerUsuario(correo);
                return obj;
            }
            else
            {
                userDT obj = new userDT();
                obj.perfil = "No existe";
                return obj;
            }
        }

        public static userDT obtenerUsuario(string correo)
        {
            cornershopEntities db = new cornershopEntities();
            var obj = db.usuarios.Select(b =>
            new userDT()
            {
                codusu = b.cod_usu,
                tipousu = b.tipo_usu,
                nomusu = b.nom_usu,
                apellido = b.apellido,
                correo = b.correo,
                activacion = b.activacion,
                perfil = b.perfil
            }).SingleOrDefault(b => b.correo == correo);
            return obj;
        }

        public static userDT registrarUsuario(userDT usu)
        {
            verificacionCorner email = new verificacionCorner();
            cornershopEntities db = new cornershopEntities();
            int existe = db.usuarios.Where(t => t.correo == usu.correo).Count();
            if (existe > 0)
            {
                return null;
            }
            else 
            {
                Random random = new Random();
                string codigo = random.Next(100000, 999999).ToString();
                string contador = db.usuarios.Count().ToString();
                email.enviarVerificacion(usu.correo, codigo);
                usuario obj = new usuario()
                {
                    cod_usu = "USU" + contador,
                    tipo_usu = "Comprador",
                    nom_usu = usu.nomusu,
                    apellido = usu.apellido,
                    correo = usu.correo,
                    password = usu.password,
                    activacion = codigo,
                    perfil = "0"
                };
                db.usuarios.Add(obj);
                db.SaveChanges();
                return obtenerUsuario(obj.correo);
            }
            
        }

        public static bool verificarperfil(string id)
        {
            cornershopEntities db = new cornershopEntities();
            usuario obj = db.usuarios.SingleOrDefault(m => m.cod_usu == id);
            obj.perfil = "1";
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}