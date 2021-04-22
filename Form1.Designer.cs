
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
			this.pnl_details = new System.Windows.Forms.Panel();
			this.lb_explanation = new System.Windows.Forms.Label();
			this.lb_transcript = new System.Windows.Forms.Label();
			this.lb_title_text = new System.Windows.Forms.Label();
			this.lb_title = new System.Windows.Forms.Label();
			this.lb_id = new System.Windows.Forms.Label();
			this.controls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.image_showcase)).BeginInit();
			this.pnl_details.SuspendLayout();
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
			// pnl_details
			// 
			this.pnl_details.Controls.Add(this.lb_explanation);
			this.pnl_details.Controls.Add(this.lb_transcript);
			this.pnl_details.Controls.Add(this.lb_title_text);
			this.pnl_details.Controls.Add(this.lb_title);
			this.pnl_details.Controls.Add(this.lb_id);
			this.pnl_details.Location = new System.Drawing.Point(0, 95);
			this.pnl_details.Name = "pnl_details";
			this.pnl_details.Size = new System.Drawing.Size(339, 500);
			this.pnl_details.TabIndex = 3;
			// 
			// lb_explanation
			// 
			this.lb_explanation.AutoSize = true;
			this.lb_explanation.Location = new System.Drawing.Point(3, 93);
			this.lb_explanation.MaximumSize = new System.Drawing.Size(200, 0);
			this.lb_explanation.Name = "lb_explanation";
			this.lb_explanation.Size = new System.Drawing.Size(65, 13);
			this.lb_explanation.TabIndex = 4;
			this.lb_explanation.Text = "Explanation:";
			// 
			// lb_transcript
			// 
			this.lb_transcript.AutoSize = true;
			this.lb_transcript.Location = new System.Drawing.Point(3, 69);
			this.lb_transcript.MaximumSize = new System.Drawing.Size(200, 0);
			this.lb_transcript.Name = "lb_transcript";
			this.lb_transcript.Size = new System.Drawing.Size(57, 13);
			this.lb_transcript.TabIndex = 3;
			this.lb_transcript.Text = "Transcript:";
			// 
			// lb_title_text
			// 
			this.lb_title_text.AutoSize = true;
			this.lb_title_text.Location = new System.Drawing.Point(3, 46);
			this.lb_title_text.MaximumSize = new System.Drawing.Size(200, 0);
			this.lb_title_text.Name = "lb_title_text";
			this.lb_title_text.Size = new System.Drawing.Size(50, 13);
			this.lb_title_text.TabIndex = 2;
			this.lb_title_text.Text = "Title text:";
			// 
			// lb_title
			// 
			this.lb_title.AutoSize = true;
			this.lb_title.Location = new System.Drawing.Point(3, 23);
			this.lb_title.Name = "lb_title";
			this.lb_title.Size = new System.Drawing.Size(30, 13);
			this.lb_title.TabIndex = 1;
			this.lb_title.Text = "Title:";
			// 
			// lb_id
			// 
			this.lb_id.AutoSize = true;
			this.lb_id.Location = new System.Drawing.Point(3, 0);
			this.lb_id.Name = "lb_id";
			this.lb_id.Size = new System.Drawing.Size(21, 13);
			this.lb_id.TabIndex = 0;
			this.lb_id.Text = "ID:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 661);
			this.Controls.Add(this.pnl_details);
			this.Controls.Add(this.image_showcase);
			this.Controls.Add(this.controls);
			this.Name = "Form1";
			this.Text = "Form1";
			this.controls.ResumeLayout(false);
			this.controls.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.image_showcase)).EndInit();
			this.pnl_details.ResumeLayout(false);
			this.pnl_details.PerformLayout();
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
		private System.Windows.Forms.Panel pnl_details;
		private System.Windows.Forms.Label lb_transcript;
		private System.Windows.Forms.Label lb_title_text;
		private System.Windows.Forms.Label lb_title;
		private System.Windows.Forms.Label lb_id;
		private System.Windows.Forms.Label lb_explanation;
	}
}

