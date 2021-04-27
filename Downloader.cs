using System;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Xml;

namespace xkcd_comics
{
	static class Downloader
	{
		public readonly static string downloadPath = LocalFiles.tempDir;

        /*
         * Checks if the application has internet access by pinging https://xkcd.com
         * Returns true of has connection, false otherwise
         * currently unstable and unused
         */
        public static bool HasConnection(int timeoutMs = 10000)
        {
            try
            {
                string url = "https://xkcd.com";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*
         * Gets and saves an image by url
         * Return true if everything went well, false otherwise
         */
        public static bool GetImageByUrl(string filename, string url)
        {
			try
			{
				using (WebClient client = new WebClient())
				{
                    Stream stream = client.OpenRead(url);
                    Bitmap bitmap = new Bitmap(stream);

					if (!Directory.Exists(downloadPath))
					{
						Directory.CreateDirectory(downloadPath);
					}
					if (bitmap != null)
					{
						bitmap.Save(downloadPath + filename, ImageFormat.Png);
					}
					
					stream.Flush();
                    stream.Close();
                    client.Dispose();
				}
                    

                return true;
			}
			catch
			{
				return false;
			}

		}

		/*
		 * Takes an image ID as input and finds all nessecary information
		 * Returns an Xkcd_data object with said data
		 */
		public static Xkcd_data GetDataByID(int id)
		{
			try
			{
				using (WebClient client = new WebClient())
				{
					string title;
					string titleText;
					string transcript;
					string imgUrl;
					string explanation;

					string url = "https://www.explainxkcd.com/wiki/index.php/" + id;
					string page = client.DownloadString(url);
                    //Console.WriteLine(page);

                    title = new Regex("<td style=\"font-size: 20px; padding-bottom:10px\"><b>").Split(page)[1];
					title = title.Split('<')[0];
					//Console.WriteLine(title);

					imgUrl = new Regex("src=\"(?=/wiki/images/)").Split(page)[1];
					imgUrl = imgUrl.Split('"')[0];
					imgUrl = "https://www.explainxkcd.com" + imgUrl;
					//Console.WriteLine(imgUrl);

					titleText = new Regex("Title text:</span>").Split(page)[1];
					titleText = titleText.Split('<')[0];
					//Console.WriteLine(titleText);

					transcript = new Regex("Transcript\">edit</a><span class=\"mw-editsection-bracket\">]</span></span></h2>").Split(page)[1];
					transcript = new Regex("<h2><span class=\"mw-headline").Split(transcript)[0];
					transcript = new Regex("<.+?>").Replace(transcript, "");
					//Console.WriteLine(transcript);

					explanation = new Regex("Explanation\">edit</a><span class=\"mw-editsection-bracket\">]</span></span></h2>").Split(page)[1];
					explanation = new Regex("<h2><span class=\"mw-headline\" id=\"Transcript\">Transcript").Split(explanation)[0];
					//explanation = new Regex("<.+?>").Replace(explanation, "");
					explanation = new Regex("<sup>.+?</sup>|<.+?>").Replace(explanation, "");
					//Console.WriteLine(explanation);

                    Xkcd_data data = new Xkcd_data(id, title, titleText, transcript, imgUrl, explanation);

					return data;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		/*
		 * Queries https://relevantxkcd.appspot.com with some search text
		 * Returns the ID of the image that's the likeliest hit
		 */
		public static int Query(string search)
		{
			try
			{
				using (WebClient client = new WebClient())
				{
					string url = "https://relevantxkcd.appspot.com/process?action=xkcd&query=" + search;
					string response = client.DownloadString(url);
					Console.WriteLine("Response");
					Console.WriteLine(response);

					string likeliest = response.Split('\n')[2].Split(' ')[0];
					Console.WriteLine("likely");
					Console.WriteLine(likeliest);

					bool isNumeric = int.TryParse(likeliest, out int numeric);

					client.Dispose();

					if (isNumeric)
					{
						return numeric;
					}
					return 0;
				}
			}
			catch
			{
				return 0;
			}
		}

		/*
		 * Retrieves the latest comic and returns the ID
		 */
		public static int GetLatest()
		{
			try
			{
				using (WebClient client = new WebClient())
				{
					string url = "https://xkcd.com/atom.xml";
					string response = client.DownloadString(url);

					XmlDocument xmlDoc = new XmlDocument();
					xmlDoc.LoadXml(response);
					XmlNodeList ids = xmlDoc.GetElementsByTagName("id");

					return Int32.Parse(ids[1].InnerText.Split('/')[3]);
				}
			}
			catch
			{
				return 0;
			}
		}
	}
}
