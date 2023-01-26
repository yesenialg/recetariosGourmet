using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace EnviarCorreoElectronico
{
    public class GestorCorreo
    {
        private SmtpClient cliente;
        private static IConfiguration Configuration { get; set; }
        private MailMessage email;
        public GestorCorreo()
        {
            cliente = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("pruebasdev.yesenia@gmail.com", "ddwlzldfcypgmccv")
            };
        }
        public void EnviarCorreo(string destinatario, string asunto, string mensaje, bool esHtlm = false)
        {
            email = new MailMessage("pruebasdev.yesenia@gmail.com", destinatario, asunto, mensaje);
            email.IsBodyHtml = esHtlm;
            cliente.Send(email);
        }
        public void EnviarCorreo(MailMessage message)
        {
            cliente.Send(message);
        }
        public async Task EnviarCorreoAsync(MailMessage message)
        {
            await cliente.SendMailAsync(message);
        }
    }
}