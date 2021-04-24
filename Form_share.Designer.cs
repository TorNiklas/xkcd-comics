
namespace xkcd_comics
{
	partial class Form_share
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lb_sender_email = new System.Windows.Forms.Label();
			this.tb_sender_email = new System.Windows.Forms.TextBox();
			this.lb_sender_password = new System.Windows.Forms.Label();
			this.tb_sender_password = new System.Windows.Forms.TextBox();
			this.lb_sendee_email = new System.Windows.Forms.Label();
			this.db_sendee_email = new System.Windows.Forms.TextBox();
			this.btn_share = new System.Windows.Forms.Button();
			this.lb_warning = new System.Windows.Forms.Label();
			this.lb_sender_smtp_port = new System.Windows.Forms.Label();
			this.tb_sender_smtp_port = new System.Windows.Forms.TextBox();
			this.lb_smtp_server = new System.Windows.Forms.Label();
			this.tb_sender_smtp_sever = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lb_sender_email
			// 
			this.lb_sender_email.AutoSize = true;
			this.lb_sender_email.Location = new System.Drawing.Point(3, 3);
			this.lb_sender_email.Name = "lb_sender_email";
			this.lb_sender_email.Size = new System.Drawing.Size(96, 13);
			this.lb_sender_email.TabIndex = 0;
			this.lb_sender_email.Text = "Your email address";
			// 
			// tb_sender_email
			// 
			this.tb_sender_email.Location = new System.Drawing.Point(6, 20);
			this.tb_sender_email.Name = "tb_sender_email";
			this.tb_sender_email.Size = new System.Drawing.Size(150, 20);
			this.tb_sender_email.TabIndex = 1;
			// 
			// lb_sender_password
			// 
			this.lb_sender_password.AutoSize = true;
			this.lb_sender_password.Location = new System.Drawing.Point(3, 43);
			this.lb_sender_password.Name = "lb_sender_password";
			this.lb_sender_password.Size = new System.Drawing.Size(104, 13);
			this.lb_sender_password.TabIndex = 2;
			this.lb_sender_password.Text = "Your email password";
			// 
			// tb_sender_password
			// 
			this.tb_sender_password.Location = new System.Drawing.Point(6, 59);
			this.tb_sender_password.Name = "tb_sender_password";
			this.tb_sender_password.PasswordChar = '•';
			this.tb_sender_password.Size = new System.Drawing.Size(150, 20);
			this.tb_sender_password.TabIndex = 3;
			// 
			// lb_sendee_email
			// 
			this.lb_sendee_email.AutoSize = true;
			this.lb_sendee_email.Location = new System.Drawing.Point(3, 229);
			this.lb_sendee_email.Name = "lb_sendee_email";
			this.lb_sendee_email.Size = new System.Drawing.Size(124, 13);
			this.lb_sendee_email.TabIndex = 4;
			this.lb_sendee_email.Text = "Share with email address";
			// 
			// db_sendee_email
			// 
			this.db_sendee_email.Location = new System.Drawing.Point(6, 246);
			this.db_sendee_email.Name = "db_sendee_email";
			this.db_sendee_email.Size = new System.Drawing.Size(150, 20);
			this.db_sendee_email.TabIndex = 5;
			// 
			// btn_share
			// 
			this.btn_share.Location = new System.Drawing.Point(162, 3);
			this.btn_share.Name = "btn_share";
			this.btn_share.Size = new System.Drawing.Size(103, 143);
			this.btn_share.TabIndex = 6;
			this.btn_share.Text = "Share";
			this.btn_share.UseVisualStyleBackColor = true;
			this.btn_share.Click += new System.EventHandler(this.btn_share_Click);
			// 
			// lb_warning
			// 
			this.lb_warning.AutoSize = true;
			this.lb_warning.Location = new System.Drawing.Point(6, 273);
			this.lb_warning.Name = "lb_warning";
			this.lb_warning.Size = new System.Drawing.Size(25, 13);
			this.lb_warning.TabIndex = 7;
			this.lb_warning.Text = "___";
			// 
			// lb_sender_smtp_port
			// 
			this.lb_sender_smtp_port.AutoSize = true;
			this.lb_sender_smtp_port.Location = new System.Drawing.Point(3, 82);
			this.lb_sender_smtp_port.Name = "lb_sender_smtp_port";
			this.lb_sender_smtp_port.Size = new System.Drawing.Size(83, 13);
			this.lb_sender_smtp_port.TabIndex = 8;
			this.lb_sender_smtp_port.Text = "Your SMTP port";
			// 
			// tb_sender_smtp_port
			// 
			this.tb_sender_smtp_port.Location = new System.Drawing.Point(6, 98);
			this.tb_sender_smtp_port.Name = "tb_sender_smtp_port";
			this.tb_sender_smtp_port.Size = new System.Drawing.Size(150, 20);
			this.tb_sender_smtp_port.TabIndex = 9;
			this.tb_sender_smtp_port.Text = "465";
			// 
			// lb_smtp_server
			// 
			this.lb_smtp_server.AutoSize = true;
			this.lb_smtp_server.Location = new System.Drawing.Point(3, 121);
			this.lb_smtp_server.Name = "lb_smtp_server";
			this.lb_smtp_server.Size = new System.Drawing.Size(94, 13);
			this.lb_smtp_server.TabIndex = 10;
			this.lb_smtp_server.Text = "Your SMTP server";
			// 
			// tb_sender_smtp_sever
			// 
			this.tb_sender_smtp_sever.Location = new System.Drawing.Point(6, 137);
			this.tb_sender_smtp_sever.Name = "tb_sender_smtp_sever";
			this.tb_sender_smtp_sever.Size = new System.Drawing.Size(150, 20);
			this.tb_sender_smtp_sever.TabIndex = 11;
			this.tb_sender_smtp_sever.Text = "smtp.gmail.com";
			// 
			// Form_share
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(270, 338);
			this.Controls.Add(this.tb_sender_smtp_sever);
			this.Controls.Add(this.lb_smtp_server);
			this.Controls.Add(this.tb_sender_smtp_port);
			this.Controls.Add(this.lb_sender_smtp_port);
			this.Controls.Add(this.lb_warning);
			this.Controls.Add(this.btn_share);
			this.Controls.Add(this.db_sendee_email);
			this.Controls.Add(this.lb_sendee_email);
			this.Controls.Add(this.tb_sender_password);
			this.Controls.Add(this.lb_sender_password);
			this.Controls.Add(this.tb_sender_email);
			this.Controls.Add(this.lb_sender_email);
			this.Name = "Form_share";
			this.Text = "Form_share";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lb_sender_email;
		private System.Windows.Forms.TextBox tb_sender_email;
		private System.Windows.Forms.Label lb_sender_password;
		private System.Windows.Forms.TextBox tb_sender_password;
		private System.Windows.Forms.Label lb_sendee_email;
		private System.Windows.Forms.TextBox db_sendee_email;
		private System.Windows.Forms.Button btn_share;
		private System.Windows.Forms.Label lb_warning;
		private System.Windows.Forms.Label lb_sender_smtp_port;
		private System.Windows.Forms.TextBox tb_sender_smtp_port;
		private System.Windows.Forms.Label lb_smtp_server;
		private System.Windows.Forms.TextBox tb_sender_smtp_sever;
	}
}