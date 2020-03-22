using Microsoft.Extensions.Options;
using Motobike.BusinessLogic.Helper;
using Motobike.BusinessLogic.Services.Interface;
using Motobike.BusinessLogic.ViewModels.Request;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace Motobike.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOptions<SmtpOptions> _smtpOptions;

        public OrderService(IOptions<SmtpOptions> smtpOptions)
        {
            _smtpOptions = smtpOptions;
        }
        public async Task Order(OrderRequest order)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("New order", _smtpOptions.Value.FromEmail));
            emailMessage.To.Add(new MailboxAddress(_smtpOptions.Value.AdminEmail));
            emailMessage.Subject = "message";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Customer name: {order.CustomerName} \n" +
                       $"Customer phone number: {order.CustomerPhoneNumber} \n" +
                       $"Customer registry number: {order.RegistryNumber} \n" +
                       $"Customer type of number: {order.TypeOfNumber} \n" + 
                       $"Customer shape: {order.Shape} \n" + 
                       $"Customer font: {order.Font} \n" +
                       $"Customer SVG: {order.SVGData} \n" 
            };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpOptions.Value.Host, _smtpOptions.Value.Port, false);
                await client.AuthenticateAsync(_smtpOptions.Value.AuthEmail, _smtpOptions.Value.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
