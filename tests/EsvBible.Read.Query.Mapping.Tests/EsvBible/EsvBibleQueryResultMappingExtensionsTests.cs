using AutoFixture;
using ESVBible.Shared.Data.Models.EsvBible;
using FluentAssertions;
using ThriveNextGen.Read.Query.Mapping.EsvBible;
using EsvBible.TestCore.AutoFixture;
using Xunit;

namespace EsvBible.Read.Query.Mapping.Tests.EsvBible
{
    public class EsvBibleQueryResultMappingExtensions
    {
        private readonly IFixture testFixture;

        public EsvBibleQueryResultMappingExtensions()
        {
            testFixture = TestFixture.CreateAutoMockingContainer();
        }

        [Fact]
        public void EsvBook_ToBiblicalOrderResultDTO_Should_Map_Correctly()
        {
            // Arrange
            var esvBook = testFixture.Create<EsvBook>();
            
            // Act
            var resultDTO = esvBook.ToBiblicalOrderResultDTO();
            
            // Assert
            resultDTO.Id.Should().Be(esvBook.Id);
            resultDTO.Name.Should().Be(esvBook.Name);
            resultDTO.NumberOfChapters.Should().Be(esvBook.Chapters.Count);
        }
        
        [Fact]
        public void EsvBook_ToABCOrderResultDTO_Should_Map_Correctly()
        {
            // Arrange
            var esvBook = testFixture.Create<EsvBook>();
            
            // Act
            var resultDTO = esvBook.ToABCOrderResultDTO();
            
            // Assert
            resultDTO.Id.Should().Be(esvBook.Id);
            resultDTO.Name.Should().Be(esvBook.Name);
            resultDTO.NumberOfChapters.Should().Be(esvBook.Chapters.Count);
        }
    }
}