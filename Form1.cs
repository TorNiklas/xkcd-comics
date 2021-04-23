using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Newtonsoft.Json.Linq;

namespace xkcd_comics
{
	public partial class Form1 : Form
	{
		private int currentID = 1;

		//need this because (0, 0) != Form1.Location
		private int currentHeight;
		private int currentWidth;
		private readonly int heightOffset = 39;
		private readonly int widthOffset = 15;

		public Form1()
		{
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
			this.Resize += new EventHandler(Form1_Resize);
			this.ResizeEnd += new EventHandler(Form1_ResizeEnd);
			InitializeComponent();
			lb_details.MaximumSize = new Size(image_showcase.Location.X, 0);
			GetAndPresentImageForCurrentID();

			//this is just to ensure that everything fits from the get go
			Form1_Resize(null, null);
			Form1_ResizeEnd(null, null);
		}

		private void Form1_ResizeEnd(object sender, EventArgs e)
		{
			//didn't do this in Form1_Resize because it causes lag because of the loop
			FixFontSize();
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			currentHeight = this.Height - heightOffset;
			currentWidth = this.Width - widthOffset;

			int markX = (int)(currentWidth * 0.3);
			markX = markX > pnl_controls.Width ? markX : pnl_controls.Width;

			//image showcase
			image_showcase.Location = new Point(markX, 0);
			image_showcase.Size = new Size(currentWidth - markX, currentHeight);

			//details label
			lb_details.MaximumSize = new Size(markX - 6, currentHeight - lb_details.Location.Y);
		}

		private void btn_search_Click(object sender, EventArgs e)
		{
			string input = tb_search.Text;
			bool isNumeric = int.TryParse(input, out int numericInput);

			if(isNumeric)
			{
				currentID = numericInput;
			}
			else
			{
				currentID = Downloader.Query(input);
			}
			GetAndPresentImageForCurrentID();
		}

		private void btn_prev_Click(object sender, EventArgs e)
		{
			currentID -= 1;
			GetAndPresentImageForCurrentID();
		}

		private void btn_next_Click(object sender, EventArgs e)
		{
			currentID += 1;
			GetAndPresentImageForCurrentID();
		}

		void OnProcessExit(object sender, EventArgs e)
		{
			Console.WriteLine("I'm out of here");

			DirectoryInfo dir = new DirectoryInfo(Downloader.downloadPath);

			try
			{
				image_showcase.Image.Dispose();
				foreach (FileInfo file in dir.GetFiles())
				{
					file.Delete();
				}
			}
			catch { }
		}

		/*
		 * Retrieves the image with ID = currentID, and all relevant information
		 * and presents both the image and the information in the relevant showcase
		 */
		private void GetAndPresentImageForCurrentID()
		{
			if (Downloader.HasConnection())
			{
				Xkcd_data data = Downloader.GetDataByID(currentID);

				if (Downloader.GetImageByUrl(currentID+"", data.imgUrl))
				{
					if (image_showcase.Image != null)
					{
						image_showcase.Image.Dispose();
					}
					string dlPath = Downloader.downloadPath;
					Bitmap img = new Bitmap(dlPath + currentID);
					image_showcase.Image = (Image)img;

					lb_details.Text = "";
					lb_details.Text += "ID: "			+ data.id			+ "\n\n";
					lb_details.Text += "Title: "		+ data.title		+ "\n\n";
					lb_details.Text += "Title text: "	+ data.titleText	+ "\n\n";
					lb_details.Text += "Transcript: "	+ data.transcript	+ "\n";
					lb_details.Text += "Explanation: "	+ data.explanation;

					FixFontSize();
				}
				else
				{
					lb_message.Text = "Error. Something went wrong when retrieving image.";
				}
			}
			else
			{
				lb_message.Text = "Error. No connection to https://xkcd.com.";
			}
		}

		/*
		 * Sets the font size of lb_details to fit within the window.
		 */
		public void FixFontSize()
		{
			// Only bother if there's text.
			string txt = lb_details.Text;
			if (txt.Length > 0)
			{
				int best_size = 100;
				int maxHeight = currentHeight - lb_details.Location.Y;

				for (int i = 1; i <= 26; i++)
				{
					using (Font test_font = new Font(lb_details.Font.FontFamily, i))
					{
						// See how much space the text would
						// need, specifying a maximum width.
						lb_details.Font = test_font;
						if (lb_details.Height >= maxHeight)
						{
							best_size = i - 1;
							break;
						}
					}
				}

				// Use that font size.
				lb_details.Font = new Font(lb_details.Font.FontFamily, best_size);
			}
		}
	}
}
