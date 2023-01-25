using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace jumpPochinkiBot.Modules
{
	public class SlashCommands : InteractionModuleBase<SocketInteractionContext>
	{
		[SlashCommand("author", "Trippy Majo did this")] //Responding
		public async Task Meow()
			=> await RespondAsync("OwO UwU Я сделан моей хозяйкой Trippy Majo в 2023, Version 1.0 (10.01.2023)");

		[SlashCommand("stats", "Get Your Ranked Stats, input nickname.")] //Responding
		public async Task RankedStats(string playerNickName)
		{
			//Stopwatch stopwatch = new Stopwatch();
			//stopwatch.Start();
			string rankedStats = await pubgApi.PlayersRankedStats(playerNickName).ConfigureAwait(false); //Too musch time wasted.

			string tier = "Rank " + pubgApi.tier;
			//string subTier = pubgApi.subTier;
			float kda = pubgApi.kda;
			float avgDamage = pubgApi.avgDamage;

			await ClearPrevRoles(); //Too much time wasted.

			await GiveRole(tier);

			//KDA ROLE ZONE
			if (kda <= 0.55)
			{
				await GiveRole("KDA 0.5");
			}
			else if (0.55 < kda && kda < 1.5)
			{
				await GiveRole("KDA 1");
			}
			else if (1.5 <= kda && kda < 2)
			{
				await GiveRole("KDA 1.5");
			}
			else if (2 <= kda && kda < 2.5)
			{
				await GiveRole("KDA 2");
			}
			else if (2.5 <= kda && kda < 3)
			{
				await GiveRole("KDA 2.5");
			}	
			else
			{
				await GiveRole("KDA >3");
			}

			//ADR ROLE ZONE
			if (avgDamage <= 55)
			{
				await GiveRole("ADR 50");
			}
			else if (55 < avgDamage && avgDamage < 125)
			{
				await GiveRole("ADR 100");
			}
			else if (125 <= avgDamage && avgDamage < 175)
			{
				await GiveRole("ADR 150");
			}
			else if (175 <= avgDamage && avgDamage < 225)
			{
				await GiveRole("ADR 200");
			}
			else if (225 <= avgDamage && avgDamage < 275)
			{
				await GiveRole("ADR 250");
			}
			else if (275 <= avgDamage && avgDamage < 325)
			{
				await GiveRole("ADR 300");
			}
			else
			{
				await GiveRole("ADR >350");
			}

			await RespondAsync(playerNickName + ": " + rankedStats);
			//stopwatch.Stop();
			//Console.WriteLine(stopwatch.ElapsedMilliseconds);
		}
		public async Task GiveRole(string rankName)
		{
			var roleByName = Context.Guild.Roles.FirstOrDefault(x => string.Equals(x.Name, rankName, StringComparison.CurrentCultureIgnoreCase));
			if (roleByName == null)
			{
				var role = await Context.Guild.CreateRoleAsync(rankName);
				await (Context.User as SocketGuildUser).AddRoleAsync(role);
			}
			else
			{
				var role = roleByName;
				await (Context.User as SocketGuildUser).AddRoleAsync(role);
			}
		}

		public async Task ClearPrevRoles()
		{
			var roleRankPrev = (Context.User as SocketGuildUser).Roles.FirstOrDefault(x => x.Name.StartsWith("Rank"));
			var roleKdaPrev = (Context.User as SocketGuildUser).Roles.FirstOrDefault(x => x.Name.StartsWith("KDA"));
			var roleAdrPrev = (Context.User as SocketGuildUser).Roles.FirstOrDefault(x => x.Name.StartsWith("ADR"));
			//WORKAROUND cos could not delete role and get the id of the next one instead of deleted.

			if (roleRankPrev != null)
				await (Context.User as SocketGuildUser).RemoveRoleAsync(roleRankPrev);

			if (roleKdaPrev != null)
				await (Context.User as SocketGuildUser).RemoveRoleAsync(roleKdaPrev);

			if (roleAdrPrev != null)
				await (Context.User as SocketGuildUser).RemoveRoleAsync(roleAdrPrev);
			return;
		}
	}
}
