//using JsonApiSerializer;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.IO;
using Discord.WebSocket;
using Discord.Interactions;
using System.Reflection.Metadata;
using System;

//using System.Net.Http.Headers;
//using System.Text.Json;
//using System.IO;
//using System;
namespace jumpPochinkiBot
{
	public class pubgAPI
	{
		const string pubgApiUrl = "https://api.pubg.com/shards/steam";

		static HttpClient httpClient = new HttpClient();

		public static async Task<string> CurrentSeasonId()
		{
			string seasonUrl = "/seasons";
			string responseSeasonId = await Requester(seasonUrl);

			return SeasonID.GetCurrentSeasonID(responseSeasonId);
		}
		public static async Task<string> Requester(string requestTailUrl)
		{
			//URL Construcor
			string url = pubgApiUrl + requestTailUrl;
			var token = File.ReadAllText("C:\\Users\\Admin\\source\\repos\\jumpPochinkiBot\\pubgToken.txt");

			//HttpRequester. Sending request and recieving response.
			using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
			request.Headers.Add("Accept", "application/json");
			var response = await httpClient.SendAsync(request);
			var responseContent = await response.Content.ReadAsStringAsync();

			return HandleResponse(response, responseContent);
		}

		private static string HandleResponse(HttpResponseMessage response, string responseContent)
		{
			if (response.IsSuccessStatusCode)
				return responseContent;
			else
				return null;
		}
	}

}