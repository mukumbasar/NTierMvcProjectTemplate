using Microsoft.Extensions.Options;
using MUK.NTierMvcProjectTemplate.BL.Services;
using MUK.NTierMvcProjectTemplate.Dtos.EmailConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.BL.Managers
{
	public class EmailManager : IEmailService
	{
		private readonly EmailOption _option;

		public EmailManager(IOptions<EmailOption> option)
		{
			_option = option.Value;
		}

		public void SendMail(string reciverMailAddress, string subject, string mailBody)
		{
			try
			{
				var smtpClient = new SmtpClient();

				smtpClient.EnableSsl = true;
				smtpClient.DeliveryMethod = smtpClient.DeliveryMethod;
				smtpClient.UseDefaultCredentials = false;

				smtpClient.Host = _option.ServiceEmailOption.Host;
				smtpClient.Port = _option.ServiceEmailOption.Port;
				smtpClient.Credentials = new NetworkCredential(_option.ServiceEmailOption.Email, _option.ServiceEmailOption.Password);

				var mailMessage = new MailMessage();

				mailMessage.From = new MailAddress(_option.ServiceEmailOption.Email);

				mailMessage.To.Add(reciverMailAddress);
				mailMessage.Subject = subject;
				mailMessage.Body = mailBody;
				mailMessage.IsBodyHtml = true;

				smtpClient.Send(mailMessage);
				Console.WriteLine("başarılı");
			}
			catch (Exception e)
			{
				Console.WriteLine("hata");
			}
			finally
			{
				Console.WriteLine("mail işlemi tamamlandı");
			}
		}
	}
}
