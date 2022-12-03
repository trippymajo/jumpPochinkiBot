using System;
using System.Reflection;
using System.Threading.Tasks;

using Discord;
using Discord.Interactions;
using Discord.WebSocket;


namespace jumpPochinkiBot
{
	public class InteractionHandler
	{
		private readonly DiscordSocketClient _client;
		private readonly InteractionService _handler;
		private readonly IServiceProvider _services;

		public InteractionHandler(DiscordSocketClient client, InteractionService handler, IServiceProvider services)
		{
			_client = client;
			_handler = handler;
			_services = services;
		}

		public async Task InitializeAsync()
		{
			_client.Ready += ReadyAsync;

			// Add the public modules that inherit InteractionModuleBase<T> to the InteractionService
			await _handler.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

			// Process the InteractionCreated payloads to execute Interactions commands
			_client.InteractionCreated += HandleInteraction;
		}

		private async Task ReadyAsync()
		{
			//IT IS REALLY IMPORTANT!
			// Context & Slash commands can be automatically registered, but this process needs to happen after the client enters the READY state.
			// Since Global Commands take around 1 hour to register, we should use a test guild to instantly update and test our commands.
			await _handler.RegisterCommandsGloballyAsync(true);
		}


		private async Task HandleInteraction(SocketInteraction interaction)
		{
			try
			{
				var context = new SocketInteractionContext(_client, interaction);
				var result = await _handler.ExecuteCommandAsync(context, _services);

				if (!result.IsSuccess)
					switch (result.Error)
					{
						case InteractionCommandError.UnmetPrecondition:
							// implement
							break;
						default:
							break;
					}
			}
			catch
			{
				// If Slash Command execution fails it is most likely that the original interaction acknowledgement will persist. It is a good idea to delete the original
				// response, or at least let the user know that something went wrong during the command execution.
				if (interaction.Type is InteractionType.ApplicationCommand)
					await interaction.GetOriginalResponseAsync().ContinueWith(async (msg) => await msg.Result.DeleteAsync());
			}
		}
	}
}
