// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standatd.AI.Data.EntityIntelligence.Models.Exceptions
{
    public class InvalidAIQueryException : Xeption
    {
        public InvalidAIQueryException()
            : base (message: "Invalid AI Query error occured, fix the errors and try again.")
        { }
    }
}
