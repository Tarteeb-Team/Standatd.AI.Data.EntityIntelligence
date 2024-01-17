// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standatd.AI.Data.EntityIntelligence.Models.Exceptions
{
    public class AIQueryDependencyValidationException : Xeption
    {
        public AIQueryDependencyValidationException(Xeption innerException)
            : base(message: "AI dependency validation error occurred, fix the errors and try again.")
        { }
    }
}
