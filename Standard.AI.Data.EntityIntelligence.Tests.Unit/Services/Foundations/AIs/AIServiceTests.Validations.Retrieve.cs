// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;
using Standatd.AI.Data.EntityIntelligence.Models.Exceptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.AIs
{
    public partial class AIServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveIfQueryIsInvalidAsync(
            string invalidAIQuery)
        {
            // given
            var invalidAIQueryException = new InvalidAIQueryException();

            var expectedAIQueryValidationException =
                new AIQueryValidationException(invalidAIQueryException);

            // when
            ValueTask<string> retrievedSqlQueryTask =
                this.aiService.RetrieveSqlQueryAsync(invalidAIQuery);

            var actualAIQueryValidationException =
                await Assert.ThrowsAsync<AIQueryValidationException>(
                    retrievedSqlQueryTask.AsTask);

            // then
            actualAIQueryValidationException.Should()
                .BeEquivalentTo(expectedAIQueryValidationException);

            this.aiBrokerMock.Verify(broker =>
                broker.PromptCompletionAsync(
                    It.IsAny<Completion>()), Times.Never);

            this.aiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
