using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace xkcd_comics
{
	public partial class Form_comics : Form
	{
		private int currentID = 1;
		private int latestID;
		private readonly Form_share shareForm;
		private readonly Thread updateThread;
		private bool exitThread = false;
		private int favIndex = 0;

		//need this because (0, 0) != Form_comics.Location
		private int currentHeight;
		private int currentWidth;
		private readonly int heightOffset = 39;
		private readonly int widthOffset = 15;

		public Form_comics()
		{

			InitializeComponent();

			//Event handlers
			this.FormClosing += new FormClosingEventHandler(OnFormClose);
			this.Resize += new EventHandler(OnResize);
			tb_search.KeyDown += new KeyEventHandler(OnTbKeypress);

			//Init
			lb_details.MaximumSize = new Size(image_showcase.Location.X-10, 0);
			GetAndPresentImageForID(currentID);
			shareForm = new Form_share(this);
			pnl_details.Location = new Point(6, pnl_details.Location.Y);

			//this is just to ensure that everything fits from the get go
			OnResize(null, null);

			//Thread
			updateThread = new Thread(new ThreadStart(UpdateThreadFunction));
			updateThread.Start();
		}

		private void OnResize(object sender, System.EventArgs e)
		{
			currentHeight = this.Height - heightOffset;
			currentWidth = this.Width - widthOffset;

			//divider between image showcase and controls/details panel
			int markX = (int)(currentWidth * 0.3);
			markX = markX > pnl_controls.Width ? markX : pnl_controls.Width;

			//image showcase
			image_showcase.Location = new Point(markX, 0);
			image_showcase.Size = new Size(currentWidth - markX, currentHeight);

			//details
			pnl_details.Size = new Size(markX - pnl_details.Location.X, currentHeight - pnl_details.Location.Y);
			lb_details.MaximumSize = new Size(pnl_details.Size.Width - 15, currentHeight - lb_details.Location.Y);

			lb_latest_comic.MaximumSize = new Size((markX - 6) - lb_latest_comic.Location.X, 0);
		}

		private void Btn_search_Click(object sender, EventArgs e)
		{
			string input = tb_search.Text;
			bool isNumeric = int.TryParse(input, out int numericInput);
			int id = currentID;

			if(isNumeric)
			{
				id = numericInput;
			}
			else
			{
				int response = Downloader.Query(input);
				if(response >= 1 && response <= latestID)
				{
					id = response;
				}
			}
			GetAndPresentImageForID(id);
		}

		private void Btn_share_Click(object sender, EventArgs e)
		{
			shareForm.Show();
			shareForm.BringToFront();
		}

		private void Btn_prev_Click(object sender, EventArgs e)
		{
			if (!cb_online.Checked)
			{
				int[] favorites = LocalFiles.GetFavorites();
				if (favorites.Length == 0) { return; }

				favIndex = (favIndex>0) ? favIndex-1 : favorites.Length-1;
				GetAndPresentImageForID(favorites[favIndex]);
			}
			else if (currentID > 1)
			{
				GetAndPresentImageForID(currentID - 1);
			}
		}

		private void Btn_next_Click(object sender, EventArgs e)
		{
			if(!cb_online.Checked)
            {
				int[] favorites = LocalFiles.GetFavorites();
				if(favorites.Length == 0) { return; }

				favIndex = (favIndex + 1) % favorites.Length;
				GetAndPresentImageForID(favorites[favIndex]);
            }
			else if(currentID < latestID)
			{
				GetAndPresentImageForID(currentID + 1);
			}
		}

		private void Btn_favorite_Click(object sender, EventArgs e)
		{
			if(LocalFiles.GetFavorites().Contains(currentID))
            {
				int id = currentID;
				if(cb_online.Checked)
                {
					btn_favorite.Text = "Favorite";
                }
				else
                {
					Btn_next_Click(null, null);
				}
				LocalFiles.Unfavorite(id);
			}
			else
            {
				LocalFiles.Favorite(currentID);
				btn_favorite.Text = "Unfavorite";
			}
		}

		private void OnTbKeypress(object sender, KeyEventArgs e)
		{
			if(e.KeyValue == 13) //enter
            {
				Btn_search_Click(null, null);
				e.Handled = true;
				e.SuppressKeyPress = true; //to stop the ding sound, and we don't need enter to do anything else
			}
		}

		void OnFormClose(object sender, EventArgs e)
		{
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
		 * Retrieves the image with ID id, and all relevant information
		 * and presents both the image and the information in the relevant showcase
		 */
		private void GetAndPresentImageForID(int id)
		{
			bool isFavorite = LocalFiles.GetFavorites().Contains(id);
            bool isDownloaded = LocalFiles.GetNonFavorites().Contains(id);

			if (cb_online.Checked)
			{
				Xkcd_data data = Downloader.GetDataByID(id);

				if (Downloader.GetImageByUrl(id + "", data.imgUrl))
				{
					if (image_showcase.Image != null)
					{
						image_showcase.Image.Dispose();
					}
					string dlPath = Downloader.downloadPath;
					Bitmap img = new Bitmap(dlPath + id);
					image_showcase.Image = (Image)img;

					string text = "";
					text += "ID: " + data.id + "\n\n";
					text += "Title: " + data.title + "\n\n";
					text += "Title text: " + data.titleText + "\n\n";
					text += "Transcript: " + data.transcript + "\n";
					text += "Explanation: " + data.explanation;

					//Fix encoding
					byte[] bytes = Encoding.Default.GetBytes(text);
					text = Encoding.UTF8.GetString(bytes);

					lb_details.Text = text;

					currentID = id;
				}
			}
			else if (isFavorite)
			{
				if (image_showcase.Image != null)
				{
					image_showcase.Image.Dispose();
				}
				string filePath = LocalFiles.favDir;
				Bitmap img = new Bitmap(filePath + id);
				image_showcase.Image = (Image)img;
				lb_details.Text = "N/A";
				currentID = id;
			}
			else if(isDownloaded)
            {
				if (image_showcase.Image != null)
				{
					image_showcase.Image.Dispose();
				}
				string filePath = LocalFiles.tempDir;
				Bitmap img = new Bitmap(filePath + id);
				image_showcase.Image = (Image)img;
				lb_details.Text = "N/A";
				currentID = id;
			}
			else
            {
				lb_message.Text = "Error. No connection.";
            }

			if (LocalFiles.GetFavorites().Contains(id))
			{
				btn_favorite.Text = "Unfavorite";
			}
			else
			{
				btn_favorite.Text = "Favorite";
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

						//Always on top
						MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.None, 
							MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
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
				Thread.Sleep(10 * 1000); //Sleep 10 sec
			}
		}

		public void UpdateLatest()
		{
			lb_latest_comic.Text = "Latest comic has ID: " + latestID;
		}
    }
}
