using System;
using System.Threading.Tasks;

using Discord;
using Discord.Interactions;

namespace jumpPochinkiBot.Modules
{
	public class SlashCommands : InteractionModuleBase<SocketInteractionContext>
	{
		[SlashCommand("meow", "Doing OwO UwU 4 U")]
		public async Task meow()
			=> await RespondAsync("Meow-Meow-Meow OwO UwU");

	}
}
