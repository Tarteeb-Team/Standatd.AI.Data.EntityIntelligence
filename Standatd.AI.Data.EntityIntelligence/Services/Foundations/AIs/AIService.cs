// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standatd.AI.Data.EntityIntelligence.Brokers.OpenAIs;

namespace Standatd.AI.Data.EntityIntelligence.Services.Foundations.AIs
{
    public class AIService : IAIService
    {
        private readonly IAIBroker aiBroker;

        public AIService(IAIBroker aiBroker) =>
            this.aiBroker = aiBroker;

        public ValueTask<string> RetrieveSqlQueryAsync(string naturalQuery) =>
            throw new System.NotImplementedException();
    }
}
