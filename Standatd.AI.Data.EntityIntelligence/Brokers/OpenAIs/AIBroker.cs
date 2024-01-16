// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standard.AI.OpenAI.Clients.OpenAIs;
using Standard.AI.OpenAI.Models.Configurations;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;
using Standatd.AI.Data.EntityIntelligence.Models.Foundations.AIs;

namespace Standatd.AI.Data.EntityIntelligence.Brokers.OpenAIs
{
    public class AIBroker : IAIBroker
    {
        private readonly AIConfigurations aIConfigurations;
        private readonly IOpenAIClient openAIClient;

        public AIBroker(AIConfigurations aIConfigurations)
        {
            this.aIConfigurations = aIConfigurations;
            this.openAIClient = InitializeOpenAIClient();
        }

        public async ValueTask<Completion> PromptCompletionAsync(Completion completion) =>
            await this.openAIClient.Completions.PromptCompletionAsync(completion);

        private IOpenAIClient InitializeOpenAIClient()
        {
            var openAIConfigurations = new OpenAIConfigurations();
            openAIConfigurations.ApiKey = this.aIConfigurations.AIApiKey;

            return new OpenAIClient(openAIConfigurations);
        }
    }
}
