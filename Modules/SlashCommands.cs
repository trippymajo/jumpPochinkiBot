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
		public async Task meow()
			=> await RespondAsync("Meow-Meow-Meow OwO UwU");

		[SlashCommand("role", "Giving you a cute role")] // Adding role here
		public async Task role ()
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
		[SlashCommand("apitest", "I want a request")] //Responding
		public async Task apitest()
		{
			string response = await pubgAPI.CurrentSeasonId().ConfigureAwait(false);
			string seasons = "Seasons info has arrived. Check console 4 It.";
			await RespondAsync(response);
		}

	}
}
