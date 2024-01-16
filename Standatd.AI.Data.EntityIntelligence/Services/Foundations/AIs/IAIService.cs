// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;

namespace Standatd.AI.Data.EntityIntelligence.Services.Foundations.AIs
{
    public interface IAIService
    {
        ValueTask<string> RetrieveSqlQueryAsync(string naturalQuery);
    }
}
