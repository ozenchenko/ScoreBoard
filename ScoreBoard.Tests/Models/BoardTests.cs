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

        [Fact]
        public void GetSummary_ReturnsCorrectSummary()
        {
            //Arrange
            var sut = new Board();
            var event1 = new Event("Mexico", "Canada");
            sut.Start(event1);
            sut.Update(event1.Id, 0, 5);

            var event2 = new Event("Spain", "Brazil");
            sut.Start(event2);
            sut.Update(event2.Id, 10, 2);

            var event3 = new Event("Germany", "France");
            sut.Start(event3);
            sut.Update(event3.Id, 2, 2);

            var event4 = new Event("Uruguay", "Italy");
            sut.Start(event4);
            sut.Update(event4.Id, 6, 6);

            var expectedSummary = new List<Event> { event2, event4, event1, event3 };

            //Act
            var actualSummary = sut.GetSummary();

            //Assert
            actualSummary.Should().BeEquivalentTo(expectedSummary, options => options.WithStrictOrdering());
        }
    }
}
