using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Cornershop.Transfer;
namespace Cornershop.Models
{
    public class verificacionCorner
    {
        public void enviarVerificacion(string destino, string codigo)
        {
            string origen = "cornershopsoa@gmail.com";
            string password = "cornershopsoa1522250";
            string titulo = "Verificación Corner Shop";
            string cuerpo = "Su código de verificación es: "+codigo;
            MailMessage mail = new MailMessage(origen,destino,titulo,cuerpo);
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential(origen,password);

            smtp.Send(mail);
            smtp.Dispose();
        }

        public void enviarVerificacionTienda(string destino, tiendaDT tiendaDao)
        {
            string origen = "cornershopsoa@gmail.com";
            string password = "cornershopsoa1522250";
            string titulo = "Verificación de tienda Corner Shop "+ tiendaDao.nomTienda;
            string cuerpo = "<p>Se registró una tienda con los siguientes datos:</p>";
            cuerpo += "<ul> <li> Nombre de Tienda: " + tiendaDao.nomTienda + "</li> ";
            cuerpo += "<li> Dirección de Tienda: " + tiendaDao.dirTienda + " </li>";
            cuerpo += "<li> Teléfono de tienda: " + tiendaDao.telefono + " </li>";
            cuerpo += "<li> Celular de tienda: " + tiendaDao.celular + " </li><ul> ";
            MailMessage mail = new MailMessage(origen, destino, titulo, cuerpo);
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential(origen, password);

            smtp.Send(mail);
            smtp.Dispose();

    }
}
}