using AutoFixture;
using FluentAssertions;
using ThriveNextGen.Read.Query.Mapping.EsvBible;
using ThriveNextGen.Read.Query.Transport.EsvBible.Input;
using EsvBible.TestCore.AutoFixture;
using Xunit;

namespace EsvBible.Read.Query.Mapping.Tests.EsvBible
{
    public class EsvBibleQueryInputMappingExtensionsTests
    {
        private readonly IFixture testFixture;

        public EsvBibleQueryInputMappingExtensionsTests()
        {
            testFixture = TestFixture.CreateAutoMockingContainer();
        }
        
        [Fact]
        public void GetEsvBookNamesInAlphabeticalOrderInputDTO_ToQuery_Should_Map_Correctly()
        {
            // Arrange
            var inputDTO = testFixture.Create<GetEsvBookNamesInAlphabeticalOrderInputDTO>();
            
            // Act
            var resultDTO = inputDTO.ToQuery();
            
            // Assert
            resultDTO.SortDirection.Should().Be(inputDTO.SortDirection);
        }
    }
}