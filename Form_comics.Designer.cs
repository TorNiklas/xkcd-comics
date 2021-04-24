
namespace xkcd_comics
{
	partial class Form_comics
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
			this.pnl_controls = new System.Windows.Forms.Panel();
			this.lb_message = new System.Windows.Forms.Label();
			this.btn_prev = new System.Windows.Forms.Button();
			this.btn_next = new System.Windows.Forms.Button();
			this.btn_search = new System.Windows.Forms.Button();
			this.tb_search = new System.Windows.Forms.TextBox();
			this.image_showcase = new System.Windows.Forms.PictureBox();
			this.lb_details = new System.Windows.Forms.Label();
			this.btn_share = new System.Windows.Forms.Button();
			this.pnl_controls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.image_showcase)).BeginInit();
			this.SuspendLayout();
			// 
			// pnl_controls
			// 
			this.pnl_controls.Controls.Add(this.btn_share);
			this.pnl_controls.Controls.Add(this.lb_message);
			this.pnl_controls.Controls.Add(this.btn_prev);
			this.pnl_controls.Controls.Add(this.btn_next);
			this.pnl_controls.Controls.Add(this.btn_search);
			this.pnl_controls.Controls.Add(this.tb_search);
			this.pnl_controls.Location = new System.Drawing.Point(0, 0);
			this.pnl_controls.Name = "pnl_controls";
			this.pnl_controls.Size = new System.Drawing.Size(325, 133);
			this.pnl_controls.TabIndex = 1;
			// 
			// lb_message
			// 
			this.lb_message.AutoSize = true;
			this.lb_message.Location = new System.Drawing.Point(12, 7);
			this.lb_message.Name = "lb_message";
			this.lb_message.Size = new System.Drawing.Size(64, 13);
			this.lb_message.TabIndex = 4;
			this.lb_message.Text = "-------------------";
			// 
			// btn_prev
			// 
			this.btn_prev.Location = new System.Drawing.Point(3, 23);
			this.btn_prev.Name = "btn_prev";
			this.btn_prev.Size = new System.Drawing.Size(100, 23);
			this.btn_prev.TabIndex = 3;
			this.btn_prev.Text = "<— Previous";
			this.btn_prev.UseVisualStyleBackColor = true;
			this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
			// 
			// btn_next
			// 
			this.btn_next.Location = new System.Drawing.Point(109, 23);
			this.btn_next.Name = "btn_next";
			this.btn_next.Size = new System.Drawing.Size(100, 23);
			this.btn_next.TabIndex = 2;
			this.btn_next.Text = "Next —>";
			this.btn_next.UseVisualStyleBackColor = true;
			this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
			// 
			// btn_search
			// 
			this.btn_search.Location = new System.Drawing.Point(109, 70);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(100, 23);
			this.btn_search.TabIndex = 1;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = true;
			this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
			// 
			// tb_search
			// 
			this.tb_search.Location = new System.Drawing.Point(3, 72);
			this.tb_search.Name = "tb_search";
			this.tb_search.Size = new System.Drawing.Size(100, 20);
			this.tb_search.TabIndex = 0;
			// 
			// image_showcase
			// 
			this.image_showcase.BackColor = System.Drawing.Color.Silver;
			this.image_showcase.Location = new System.Drawing.Point(470, 0);
			this.image_showcase.Name = "image_showcase";
			this.image_showcase.Size = new System.Drawing.Size(514, 506);
			this.image_showcase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.image_showcase.TabIndex = 2;
			this.image_showcase.TabStop = false;
			// 
			// lb_details
			// 
			this.lb_details.AutoSize = true;
			this.lb_details.Location = new System.Drawing.Point(0, 136);
			this.lb_details.Name = "lb_details";
			this.lb_details.Size = new System.Drawing.Size(35, 13);
			this.lb_details.TabIndex = 4;
			this.lb_details.Text = "label1";
			// 
			// btn_share
			// 
			this.btn_share.Location = new System.Drawing.Point(3, 107);
			this.btn_share.Name = "btn_share";
			this.btn_share.Size = new System.Drawing.Size(100, 23);
			this.btn_share.TabIndex = 5;
			this.btn_share.Text = "Share";
			this.btn_share.UseVisualStyleBackColor = true;
			this.btn_share.Click += new System.EventHandler(this.btn_share_Click);
			// 
			// Form_comics
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 800);
			this.Controls.Add(this.image_showcase);
			this.Controls.Add(this.lb_details);
			this.Controls.Add(this.pnl_controls);
			this.Name = "Form_comics";
			this.Text = "Form_comics";
			this.pnl_controls.ResumeLayout(false);
			this.pnl_controls.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.image_showcase)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Panel pnl_controls;
		private System.Windows.Forms.Button btn_prev;
		private System.Windows.Forms.Button btn_next;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.TextBox tb_search;
		private System.Windows.Forms.Label lb_message;
		private System.Windows.Forms.PictureBox image_showcase;
		private System.Windows.Forms.Label lb_details;
		private System.Windows.Forms.Button btn_share;
	}
}

