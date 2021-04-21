
namespace xkcd_comics
{
	partial class Form1
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
			this.controls = new System.Windows.Forms.Panel();
			this.lb_message = new System.Windows.Forms.Label();
			this.btn_prev = new System.Windows.Forms.Button();
			this.btn_next = new System.Windows.Forms.Button();
			this.btn_search = new System.Windows.Forms.Button();
			this.tb_search = new System.Windows.Forms.TextBox();
			this.image_showcase = new System.Windows.Forms.PictureBox();
			this.controls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.image_showcase)).BeginInit();
			this.SuspendLayout();
			// 
			// controls
			// 
			this.controls.Controls.Add(this.lb_message);
			this.controls.Controls.Add(this.btn_prev);
			this.controls.Controls.Add(this.btn_next);
			this.controls.Controls.Add(this.btn_search);
			this.controls.Controls.Add(this.tb_search);
			this.controls.Location = new System.Drawing.Point(0, 0);
			this.controls.Name = "controls";
			this.controls.Size = new System.Drawing.Size(325, 89);
			this.controls.TabIndex = 1;
			// 
			// lb_message
			// 
			this.lb_message.AutoSize = true;
			this.lb_message.Location = new System.Drawing.Point(12, 9);
			this.lb_message.Name = "lb_message";
			this.lb_message.Size = new System.Drawing.Size(64, 13);
			this.lb_message.TabIndex = 4;
			this.lb_message.Text = "-------------------";
			// 
			// btn_prev
			// 
			this.btn_prev.Location = new System.Drawing.Point(118, 60);
			this.btn_prev.Name = "btn_prev";
			this.btn_prev.Size = new System.Drawing.Size(75, 23);
			this.btn_prev.TabIndex = 3;
			this.btn_prev.Text = "Previous";
			this.btn_prev.UseVisualStyleBackColor = true;
			this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
			// 
			// btn_next
			// 
			this.btn_next.Location = new System.Drawing.Point(118, 32);
			this.btn_next.Name = "btn_next";
			this.btn_next.Size = new System.Drawing.Size(75, 23);
			this.btn_next.TabIndex = 2;
			this.btn_next.Text = "Next";
			this.btn_next.UseVisualStyleBackColor = true;
			this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
			// 
			// btn_search
			// 
			this.btn_search.Location = new System.Drawing.Point(12, 60);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(100, 23);
			this.btn_search.TabIndex = 1;
			this.btn_search.Text = "Search";
			this.btn_search.UseVisualStyleBackColor = true;
			this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
			// 
			// tb_search
			// 
			this.tb_search.Location = new System.Drawing.Point(12, 34);
			this.tb_search.Name = "tb_search";
			this.tb_search.Size = new System.Drawing.Size(100, 20);
			this.tb_search.TabIndex = 0;
			// 
			// image_showcase
			// 
			this.image_showcase.BackColor = System.Drawing.Color.Silver;
			this.image_showcase.Location = new System.Drawing.Point(345, 0);
			this.image_showcase.Name = "image_showcase";
			this.image_showcase.Size = new System.Drawing.Size(639, 658);
			this.image_showcase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.image_showcase.TabIndex = 2;
			this.image_showcase.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 661);
			this.Controls.Add(this.image_showcase);
			this.Controls.Add(this.controls);
			this.Name = "Form1";
			this.Text = "Form1";
			this.controls.ResumeLayout(false);
			this.controls.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.image_showcase)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel controls;
		private System.Windows.Forms.Button btn_prev;
		private System.Windows.Forms.Button btn_next;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.TextBox tb_search;
		private System.Windows.Forms.Label lb_message;
		private System.Windows.Forms.PictureBox image_showcase;
	}
}

