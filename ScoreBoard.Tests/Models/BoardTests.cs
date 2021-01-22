using AutoFixture;
using FluentAssertions;
using ScoreBoard.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ScoreBoard.Tests.Models
{
    public class BoardTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void Start_AddsNewEvent()
        {
            //Arrange
            var e = _fixture.Create<Event>();
            var expectedEvents = new List<Event> { e };
            var sut = new Board();

            //Act
            sut.Start(e);

            //Assert
            sut.Events.Should().BeEquivalentTo(expectedEvents);
        }

        [Fact]
        public void Finish_EventExists_RemovesEvent()
        {
            //Arrange
            var e = _fixture.Create<Event>();
            var sut = new Board();
            sut.Start(e);

            //Act
            sut.Finish(e.Id);

            //Assert
            sut.Events.Should().BeEmpty();
        }

        [Fact]
        public void Finish_EventDoesNotExist_ThrowsArgumentNullException()
        {
            //Arrange
            var sut = new Board();

            //Act
            Action act = () => sut.Finish(_fixture.Create<int>());

            //Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Update_EventExists_UpdatesEvent()
        {
            //Arrange
            var e = _fixture.Create<Event>();
            var newHomeTeamScore = _fixture.Create<int>();
            var newAwayTeamScore = _fixture.Create<int>();
            var sut = new Board();
            sut.Start(e);

            //Act
            sut.Update(e.Id, newHomeTeamScore, newAwayTeamScore);

            //Assert
            e.HomeTeamScore.Should().Be(newHomeTeamScore);
            e.AwayTeamScore.Should().Be(newAwayTeamScore);
        }

        [Fact]
        public void Update_EventDoesNotExist_ThrowsArgumentNullException()
        {
            //Arrange
            var sut = new Board();

            //Act
            Action act = () => sut.Update(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<int>());

            //Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
