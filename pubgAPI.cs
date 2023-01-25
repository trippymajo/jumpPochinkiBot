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
	public class pubgApi
	{
		const string pubgApiUrl = "https://api.pubg.com/shards/steam";

		static HttpClient httpClient = new HttpClient();

		public static string tier = null;
		public static string subTier = null;
		public static float kda = 0;
		public static float avgDamage = 0;
		
		public static async Task<string> PlayersRankedStats(string playerId)
		{
			string rankedStatsUrl = "/players/";
			string accountId = await PlayersAccountId(playerId);
			string seasonId = await CurrentSeasonId();
			//await Task.WhenAll(PlayersAccountId(playerId), CurrentSeasonId());
			//string accountId = PlayersAccountId(playerId).Result;
			//string seasonId = CurrentSeasonId().Result;

			rankedStatsUrl = rankedStatsUrl + accountId + "/seasons/" + seasonId + "/ranked";
			string responseRankedStats = await Requester(rankedStatsUrl);

			RankedStats.GetRankedStats(responseRankedStats);

			//Stats:
			tier = RankedStats.tier;
			subTier = RankedStats.subTier;
			kda = RankedStats.kda;
			avgDamage = RankedStats.avgDamage;


			string rankedStats = tier + " " + subTier + " kda:" + kda.ToString("0.00") +" avgDamage:"+ avgDamage.ToString("0.00");
			return rankedStats;
		}

		public static async Task<string> PlayersAccountId(string playerId)
		{
			string playersUrl = "/players?filter[playerNames]=" + playerId;
			string responseAccountId = await Requester(playersUrl);

			return AccountId.GetAccountId(responseAccountId);

		}

		public static async Task<string> CurrentSeasonId()
		{
			string seasonUrl = "/seasons";
			string responseSeasonId = await Requester(seasonUrl);

			return SeasonId.GetCurrentSeasonId(responseSeasonId);
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