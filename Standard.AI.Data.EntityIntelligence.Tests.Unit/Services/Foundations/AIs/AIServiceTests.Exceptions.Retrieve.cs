// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standard.AI.OpenAI.Models.Clients.Completions.Exceptions;
using Standard.AI.OpenAI.Models.Services.Foundations.Completions;
using Standatd.AI.Data.EntityIntelligence.Models.Exceptions;
using Xeptions;
using Xunit;

namespace Standard.AI.Data.EntityIntelligence.Tests.Unit.Services.Foundations.AIs
{
    public partial class AIServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveIfValidationErrorOccurs()
        {
            // given
            var someNaturalQuery = GetRandomString();
            var someException = new Exception();

            var completionClientValidationException =
                new CompletionClientValidationException(someException as Xeption);

            this.aiBrokerMock.Setup(broker =>
                broker.PromptCompletionAsync(It.IsAny<Completion>()))
                    .ThrowsAsync(completionClientValidationException);

            var expectedAIQueryDependencyValidationException =
                new AIQueryDependencyValidationException(completionClientValidationException);

            // when
            ValueTask<string> retrieveSqlQueryTask =
                this.aiService.RetrieveSqlQueryAsync(someNaturalQuery);

            AIQueryDependencyValidationException actualAIQueryDependencyValidationException =
                await Assert.ThrowsAsync<AIQueryDependencyValidationException>(retrieveSqlQueryTask.AsTask);

            // then
            actualAIQueryDependencyValidationException.Should()
                .BeEquivalentTo(expectedAIQueryDependencyValidationException);

            this.aiBrokerMock.Verify(broker =>
                broker.PromptCompletionAsync(
                    It.IsAny<Completion>()), Times.Once);

            this.aiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
