using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Newtonsoft.Json.Linq;

namespace xkcd_comics
{
	public partial class Form_comics : Form
	{
		private int currentID = 1;
		private int latestID;
		private Form_share shareForm;
		private Thread updateThread;
		private bool exitThread = false;

		//need this because (0, 0) != Form_comics.Location
		private int currentHeight;
		private int currentWidth;
		private readonly int heightOffset = 39;
		private readonly int widthOffset = 15;

		public Form_comics()
		{
			this.FormClosing += new FormClosingEventHandler(OnFormClose);
			this.Resize += new EventHandler(OnResize);
			this.ResizeEnd += new EventHandler(OnResizeEnd);
			InitializeComponent();
			lb_details.MaximumSize = new Size(image_showcase.Location.X, 0);
			GetAndPresentImageForCurrentID();

			//this is just to ensure that everything fits from the get go
			OnResize(null, null);
			OnResizeEnd(null, null);

			shareForm = new Form_share(this);

			updateThread = new Thread(new ThreadStart(UpdateThreadFunction));
			updateThread.Start();
		}

		private void OnResizeEnd(object sender, EventArgs e)
		{
			//didn't do this in OnResize because it causes lag because of the loop
			FixFontSize();
		}

		private void OnResize(object sender, System.EventArgs e)
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

			lb_latest_comic.MaximumSize = new Size((markX - 6) - lb_latest_comic.Location.X, 0);
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
				int response = Downloader.Query(input);
				if(response >= 1 && response <= latestID)
				{
					currentID = response;
				}
			}
			GetAndPresentImageForCurrentID();
		}

		private void btn_share_Click(object sender, EventArgs e)
		{
			shareForm.Show();
			shareForm.BringToFront();
		}

		private void btn_prev_Click(object sender, EventArgs e)
		{
			if(currentID > 1)
			{
				currentID -= 1;
				GetAndPresentImageForCurrentID();
			}
		}

		private void btn_next_Click(object sender, EventArgs e)
		{
			if(currentID < latestID)
			{
				currentID += 1;
				GetAndPresentImageForCurrentID();
			}
		}

		void OnFormClose(object sender, EventArgs e)
		{
			Console.WriteLine("I'm out of here");

			exitThread = true;

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
			Application.Exit();
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
		private void FixFontSize()
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

		public int GetCurrentID()
		{
			return currentID;
		}

		/*
		 * Function for the thread that will check for new comcis.
		 * Ideally, i'd put in a check that disables the message box
		 * on the first loop, but since it's unlikely that a new comic 
		 * will be released when testing and reviewing the app, I left
		 * it in.
		 */
		private void UpdateThreadFunction()
		{
			
			while (!exitThread)
			{
				int late = Downloader.GetLatest();
				if(late != 0)
				{
					if(latestID != late)
					{
						string message = "A new comic has been posted";
						string caption = "New comic";
						MessageBoxButtons buttons = MessageBoxButtons.OK;

						MessageBox.Show(message, caption, buttons);
					}


					latestID = late;
					if (lb_latest_comic.InvokeRequired)
					{
						MethodInvoker assignMethodControl = new MethodInvoker(UpdateLatest);
						try
						{
							lb_latest_comic.Invoke(assignMethodControl);
						}
						catch { }
					}
					else
					{
						lb_latest_comic.Text = "Latest comic has ID: " + latestID;
					}
				}
				Thread.Sleep(60 * 60 * 1000); //Sleep 1h
			}
		}

		public void UpdateLatest()
		{
			lb_latest_comic.Text = "Latest comic has ID: " + latestID;
		}
	}
}
