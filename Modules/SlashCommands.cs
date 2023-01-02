using System;
using System.Threading.Tasks;

using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace jumpPochinkiBot.Modules
{
	public class SlashCommands : InteractionModuleBase<SocketInteractionContext>
	{
		[SlashCommand("meow", "Doing OwO UwU 4 U")] //Responding
		public async Task Meow()
			=> await RespondAsync("Meow-Meow-Meow OwO UwU");

		[SlashCommand("role", "Giving you a cute role")] // Adding role here
		public async Task Role ()
		{
			ulong roleId = 1049674976342589460; // should be change to something like:

			/*
			string rankName = UwU
			var roleByName = Context.Guild.Roles.FirstOrDefault(x => string.Equals(x.Name, rankName, StringComparison.CurrentCultureIgnoreCase));
                if (roleByName == null)
                {
                    await ReplyAsync("That role does not exists!");
                    return;
                }

                role = roleByName;
			*/
			var role = Context.Guild.GetRole(roleId);
			await (Context.User as SocketGuildUser).AddRoleAsync(role);

			/* if want to delete previous roles will be useful after. when updating the adr and kd but dont forget about admin roles and etc.
			Also, ME, dont forget to check if role exists, in order to avoid exceptions.

			if ((Context.User as SocketGuildUser).Roles.Any(x => x.Id == role.Id))
            {
                await (Context.User as SocketGuildUser).RemoveRoleAsync(role);
                await ReplyAsync($"Successfully removed the rank {role.Mention} from you.");
                return;
            }
			*/
			await RespondAsync($"Successfully added the rank {role.Mention} to you.");
		}
		[SlashCommand("season", "Get Current Season's ID")] //Responding
		public async Task SeasonId()
		{
			string seasonId = await pubgApi.CurrentSeasonId().ConfigureAwait(false);
			await RespondAsync(seasonId);
		}

		[SlashCommand("account", "Get Your Account ID, input nickname.")] //Responding
		public async Task AccountId(string playerNickName)
		{
			string accountId = await pubgApi.PlayersAccountId(playerNickName).ConfigureAwait(false);
			await RespondAsync(accountId);
		}

		[SlashCommand("stats", "Get Your Ranked Stats, input nickname.")] //Responding
		public async Task RankedStats(string playerNickName)
		{
			string rankedStats = await pubgApi.PlayersRankedStats(playerNickName).ConfigureAwait(false);
			await RespondAsync(rankedStats);
		}
	}
}
