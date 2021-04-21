using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace xkcd_comics
{
	static class Downloader
	{
        public readonly static string downloadPath = Directory.GetCurrentDirectory() + "\\temp\\";
        /*
         * Checks if the application has internet access by pinging https://xkcd.com
         * Returns true of has connection, false otherwise
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

        public static bool GetImageByID(int id)
		{
			try
			{
				using (WebClient client = new WebClient())
				{

					string jsonUrl = "https://xkcd.com/" + id + "/info.0.json";
					Console.WriteLine(jsonUrl);
					Console.WriteLine("Get json");
					var st = client.DownloadString(jsonUrl);
					string imgUrl = (string)JObject.Parse(st)["img"];

					string filename = id + "";

					/*
					 * Weirdest bug I think I've ever come across.
					 * Without this the request times out. Consistently and regardless of how long i wait.
					 */
					Console.WriteLine("Start google");
					for (int i = 0; i < 20; i++)
					{
						client.DownloadString("http://www.gooogle.com");
						Console.WriteLine(i);
					}
					Console.WriteLine("Finish google");

					return GetImageByUrl(filename, imgUrl);
				}





			//HttpWebRequest request = (HttpWebRequest)WebRequest.Create(jsonUrl);

			//HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			//// Display the status.
			//Console.WriteLine(response.StatusDescription);
			//// Get the stream containing content returned by the server.
			//Stream dataStream = response.GetResponseStream();
			//// Open the stream using a StreamReader for easy access.
			//StreamReader reader = new StreamReader(dataStream);
			//// Read the content.
			//string responseFromServer = reader.ReadToEnd();
			//// Display the content.
			//Console.WriteLine(responseFromServer);
			//// Cleanup the streams and the response.
			//reader.Close();
			//dataStream.Close();
			//response.Close();
			//Thread.Sleep(10000);
			//for (int i = 0; i < 20; i++)
			//{
			//	client.DownloadString("http://www.gooogle.com");
			//	Console.WriteLine(i);
			//}


			}
            catch
			{
				Console.WriteLine(false);
                return false;
			}

}
    }
}
