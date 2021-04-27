using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace xkcd_comics
{
	public partial class Form_share : Form
	{
		private Form_comics parent;
		public Form_share(Form_comics parent)
		{
			InitializeComponent();
			this.parent = parent;
			this.FormClosing += new FormClosingEventHandler(OnClose);
		}

		//Makes and sends an email with the given information
		private void btn_share_Click(object sender, EventArgs e)
		{
			try
			{
				EmailConfiguration config = new EmailConfiguration();
				config.SmtpPort = Int32.Parse(tb_sender_smtp_port.Text);
				config.SmtpServer = tb_sender_smtp_sever.Text;
				config.SmtpUsername = tb_sender_email.Text;
				config.SmtpPassword = tb_sender_password.Text;

				EmailService service = new EmailService(config);
				EmailMessage msg = new EmailMessage();
				EmailAddress toAdress = new EmailAddress();
				toAdress.Address = lb_sendee_email.Text;
				toAdress.Address = "torniklas@outlook.com";
				EmailAddress fromAdress = new EmailAddress();
				fromAdress.Address = tb_sender_email.Text;
				msg.ToAddresses = new List<EmailAddress>() { toAdress };
				msg.FromAddresses = new List<EmailAddress>() { fromAdress };
				msg.Subject = "Check out this comic from xkcd!";
				msg.Content = "<html><body>Here's the <a href='https://xkcd.com/" + parent.GetCurrentID() + "/'>link,</a> check it out!</body></html>";
				service.Send(msg);
				lb_warning.Text = "";
			}
			catch (Exception ex)
			{
				lb_warning.Text = "Something went wrong when sending the email.";
				Console.WriteLine(ex);
			}
		}
		private void OnClose(object sender, FormClosingEventArgs e)
		{
            if (e.CloseReason == CloseReason.UserClosing)
            {
				this.Hide();
				e.Cancel = true;
            }
		}
	}
}
