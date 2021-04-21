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

namespace xkcd_comics
{
	public partial class Form1 : Form
	{
		private int currentID = 1;
		public Form1()
		{
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
			InitializeComponent();
			GetAndPresentImageForCurrentID();
		}

		private void btn_search_Click(object sender, EventArgs e)
		{
			currentID = 614;
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

		private void GetAndPresentImageForCurrentID()
		{
			if (Downloader.HasConnection())
			{
				if (Downloader.GetImageByID(currentID))
				{
					if (image_showcase.Image != null)
					{
						image_showcase.Image.Dispose();
					}
					string dlPath = Downloader.downloadPath;
					//Image img = Image.FromFile(dlPath + currentID);
					//image_showcase.Image = img;

					Bitmap img = new Bitmap(dlPath + currentID);

					image_showcase.Image = (Image)img;

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
