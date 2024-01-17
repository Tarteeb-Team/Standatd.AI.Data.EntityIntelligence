// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standatd.AI.Data.EntityIntelligence.Models.Exceptions
{
    public class AIQueryValidationException : Xeption
    {
        public AIQueryValidationException(Xeption innerException)
            : base(message: "AI Validation error occured, fix the errors and try again.", 
                  innerException)
        { }
    }
}
