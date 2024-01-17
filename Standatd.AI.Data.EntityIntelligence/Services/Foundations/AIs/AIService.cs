// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;
using Standatd.AI.Data.EntityIntelligence.Brokers.OpenAIs;

namespace Standatd.AI.Data.EntityIntelligence.Services.Foundations.AIs
{
    public partial class AIService : IAIService
    {
        private readonly IAIBroker aiBroker;

        public AIService(IAIBroker aiBroker) =>
            this.aiBroker = aiBroker;

        public ValueTask<string> RetrieveSqlQueryAsync(string naturalQuery) =>
        TryCatch(async () =>
        {
            ValidateAIQuery(naturalQuery);

            var completion = new Completion
            {
                Request = new CompletionRequest
                {
                    Prompts = new string[] {
                        naturalQuery
                    },

                    Model = "text-davinci-003",
                    MaxTokens = 100
                }
            };

            Completion completionResponse =
                await this.aiBroker.PromptCompletionAsync(completion);

            return completionResponse.Response.Choices[0].Text;
        });
    }
}
