using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xkcd_comics
{
	class Xkcd_data
	{
		public int id;
		public string title;
		public string titleText;
		public string transcript;
		public string imgUrl;
		public string explanation;

		public Xkcd_data(int id, string title, string titleText, string transcript, string imgUrl, string explanation)
		{
			this.id = id;
			this.title = title;
			this.titleText = titleText;
			this.transcript = transcript;
			this.imgUrl = imgUrl;
			this.explanation = explanation;
		}
	}
}
