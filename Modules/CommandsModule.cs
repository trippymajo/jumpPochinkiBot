using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumpPochinkiBot.Modules
{
	public class CommandsModule : ModuleBase<SocketCommandContext>
	{
        [Command("sayMeow")]
        public async Task sayMeowAsync()
		{
            await ReplyAsync("Meow Meow Meow UwU OwO!");
        }

    }
}
