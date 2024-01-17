// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standard.AI.OpenAI.Models.Clients.Completions.Exceptions;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;
using Standatd.AI.Data.EntityIntelligence.Models.Exceptions;
using Xeptions;

namespace Standatd.AI.Data.EntityIntelligence.Services.Foundations.AIs
{
    public partial class AIService
    {
        private delegate ValueTask<string> ReturningStringFunction();

        private static async ValueTask<string> TryCatch(ReturningStringFunction returningStringFunction)
        {
            try
            {
                return await returningStringFunction();
            }
            catch (InvalidAIQueryException invalidAIQueryException)
            {
                throw new AIQueryValidationException(invalidAIQueryException);
            }
            catch(CompletionClientValidationException completionClientValidationException)
            {
                throw new AIQueryDependencyValidationException(
                    completionClientValidationException.InnerException as Xeption);
            }
        }
    }
}
