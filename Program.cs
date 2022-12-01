using System;
using System.Threading.Tasks;
using System.IO;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace jumpPochinkiBot
{
	class Program
	{
		private DiscordSocketClient client;
		private CommandService commands;
		public static Task Main(string[] args)
			=> new Program().MainAsync();

		public async Task MainAsync()
		{
			client = new DiscordSocketClient();
			client.Log += Log;

			var token = File.ReadAllText("C:\\Users\\Admin\\source\\repos\\jumpPochinkiBot\\discordToken.txt");

			await client.LoginAsync(TokenType.Bot, token);
			await client.StartAsync();

			await Task.Delay(-1);
		}

		private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
		}

		
	}
}
