// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;

namespace Standatd.AI.Data.EntityIntelligence.Brokers.OpenAIs
{
    public interface IAIBroker
    {
        ValueTask<Completion> PromptCompletionAsync(Completion completion);
    }
}
