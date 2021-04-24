using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Linq;
using MimeKit.Text;
using MailKit.Net.Pop3;
using MailKit.Security;

namespace xkcd_comics
{
	public interface IEmailService
	{
		void Send(EmailMessage emailMessage);
		//List<EmailMessage> ReceiveEmail(int maxCount = 10);
		//List<EmailMessage> ReceiveLatestEmail(int maxCount = 10);
	}

	// Everything to do with the emails
	public class EmailService : IEmailService
	{
		private readonly IEmailConfiguration _emailConfiguration;

		public EmailService(IEmailConfiguration emailConfiguration)
		{
			_emailConfiguration = emailConfiguration;
		}

		//Function for sending emails
		public void Send(EmailMessage emailMessage)
		{
			var message = new MimeMessage();
			message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
			message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

			message.Subject = emailMessage.Subject; message.Body = new TextPart(TextFormat.Html)
			{
				Text = emailMessage.Content
			};

			SmtpClient emailClient = new SmtpClient();

			//The last parameter is to use SSL 
			emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);

			//Remove OAuth functionality as it's not needed
			emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

			emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
			emailClient.Send(message);
			emailClient.Disconnect(true);
		}
	}
}
