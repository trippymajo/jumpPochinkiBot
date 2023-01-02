//using JsonApiSerializer;
using Newtonsoft.Json;
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
			string seasonID = "/seasons";
			string responseSesonId = await Requester(seasonID);
			//await deserialize(responseSesonId);
			return responseSesonId;
		}
		public static async Task<string> Requester(string requestTailUrl)
		{
			string url = pubgApiUrl + requestTailUrl;
			var token = File.ReadAllText("C:\\Users\\Admin\\source\\repos\\jumpPochinkiBot\\pubgToken.txt");
			using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
			//request.Headers.Add("Accept-Encoding", "gzip");
			request.Headers.Add("Accept", "application/vnd.api+json");
			var response = await httpClient.SendAsync(request);
			var responseContent = await response.Content.ReadAsStringAsync();
			Console.WriteLine(responseContent);
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