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
using System.Drawing;
using Newtonsoft.Json.Linq;

namespace xkcd_comics
{
	public partial class Form1 : Form
	{
		private int currentID = 1;
		public Form1()
		{
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
			InitializeComponent();
			lb_transcript.MaximumSize = new Size(pnl_details.Width, 0);
			lb_explanation.MaximumSize = new Size(pnl_details.Width, 0);
			GetAndPresentImageForCurrentID();
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
					lb_id.Text = "ID: " + data.id;
					lb_title.Text = "Title: " + data.title;
					lb_title_text.Text = "Title text:" + data.titleText;

					lb_transcript.Location = new Point(lb_transcript.Location.X, lb_title_text.Location.Y + lb_title_text.Height + 10);
					lb_transcript.Text = "Transcript:" + data.transcript;

					lb_explanation.Location = new Point(lb_explanation.Location.X, lb_transcript.Location.Y + lb_transcript.Height + 10);
					lb_explanation.Text = "Explanation: " + data.explanation;
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
	}
}
