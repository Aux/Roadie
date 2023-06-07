using Discord;
using Discord.Interactions;

namespace Roadie.Commands
{
    public class VerifyModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("verify", "Verify your purchase of a configured gumroad product.")]
        public async Task VerifyAsync([Autocomplete(typeof(ProductAutocompleteHandler))]string productId)
        {
            var selected = ProductAutocompleteHandler.Options.SingleOrDefault(x => x.Value.ToString() == productId);

            var modal = new ModalBuilder("Verifying " + selected.Name, "license_input")
                .AddTextInput(
                    label: "License",
                    customId: "value",
                    placeholder: "XXXXXXXX-XXXXXXXX-XXXXXXXX-XXXXXXXX",
                    required: true);

            await RespondWithModalAsync(modal.Build());
        }

        [ModalInteraction("license_input")]
        public Task InputResponseAsync(string value)
        {
            return RespondAsync("Verified your purchase!", ephemeral: true);
        }
    }

    public class ProductAutocompleteHandler : AutocompleteHandler
    {
        public static List<AutocompleteResult> Options => new List<AutocompleteResult>
            {
                new AutocompleteResult("Texture Pack: Rexouium Tigers", "rextigers"),
                new AutocompleteResult("Texture Pack: CanisWoof Hyenas", "canishyenas"),
                new AutocompleteResult("Free Texture Pack: CanisWoof Group 2", "canis2"),
                new AutocompleteResult("Free Texture Pack: CanisWoof Group 1", "canis1"),
                new AutocompleteResult("Texture Pack: Tosca House Cats", "toscacats"),
                new AutocompleteResult("Texture Pack: Rexouium Big Cats", "rexbigcats")
            };

        public override async Task<AutocompletionResult> GenerateSuggestionsAsync(
            IInteractionContext context, 
            IAutocompleteInteraction autocompleteInteraction, 
            IParameterInfo parameter, 
            IServiceProvider services)
        {
            await Task.Delay(0);
            return AutocompletionResult.FromSuccess(Options);
        }
    }
}
