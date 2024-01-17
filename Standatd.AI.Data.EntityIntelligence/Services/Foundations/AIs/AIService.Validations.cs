﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Standatd.AI.Data.EntityIntelligence.Models.Exceptions;

namespace Standatd.AI.Data.EntityIntelligence.Services.Foundations.AIs
{
    public partial class AIService
    {
        private static void ValidateAIQuery(string naturalQuery) =>
            Validate(validations: (Rule: IsInvalid(naturalQuery), Parameter: nameof(naturalQuery)));

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required."
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidAIQueryException = new InvalidAIQueryException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidAIQueryException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidAIQueryException.ThrowIfContainsErrors();
        }
    }
}
