using AutoFixture;
using FluentAssertions;
using ScoreBoard.Models;
using System;
using Xunit;

namespace ScoreBoard.Tests.Models
{
    public class EventTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void Constructor_HomeTeamAndAwayTeamAreNotNull_InitializesNewInstance()
        {
            //Arrange
            var homeTeam = _fixture.Create<string>();
            var awayTeam = _fixture.Create<string>();

            //Act
            var e = new Event(homeTeam, awayTeam);

            //Assert
            e.HomeTeam.Should().BeEquivalentTo(homeTeam);
            e.AwayTeam.Should().BeEquivalentTo(awayTeam);
        }

        [Fact]
        public void Constructor_HomeTeamIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            string homeTeam = null;
            var awayTeam = _fixture.Create<string>();

            //Act
            Func<Event> act = () => new Event(homeTeam, awayTeam);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_AwayTeamIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var homeTeam = _fixture.Create<string>();
            string awayTeam = null;

            //Act
            Func<Event> act = () => new Event(homeTeam, awayTeam);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ToString_ReturnsCorrectString()
        {
            //Arrange
            var homeTeam = _fixture.Create<string>();
            var awayTeam = _fixture.Create<string>();
            var expectedStr = $"{homeTeam} - {awayTeam}: 0 - 0";
            var sut = new Event(homeTeam, awayTeam);

            //Act
            var str = sut.ToString();

            //Assert
            str.Should().BeEquivalentTo(expectedStr);
        }
    }
}
