using System;
using DandD.Models.Game_Files;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static DandD.Models.Game_Files.Items;
using System.Net;
using System.IO;

namespace DandD
{
    public class ItemsWebAPI
    {
        public ItemsWebAPI()
        {
        }
		public async Task<string> MakeGetRequest(string url)
		{
			var request = WebRequest.Create(url);

			HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;

			if (response.StatusCode == HttpStatusCode.OK)
			{
				using (StreamReader reader = new StreamReader(response.GetResponseStream()))
				{
					var check = reader.ReadToEnd();
					if (string.IsNullOrWhiteSpace(check))
					{
						return response.StatusCode + "EMPTY";
					}
					else
					{
						return check;
					}
				}
			}
			else
			{
				return response.StatusCode.ToString();
			}

		}


	}
}
