# ScoreBoard
Tried to keep ScoreBoard solution as simple as possible, by creating thin and clear model classes.
I used term "Event" instead of "Game" as it seems more relavant in this context(I think "Game" is more about a kind of sport rather than a concrete sport match).
Unit tests were implemented in the common "AAA" pattern, using Xunit as a framework, AutoFixture for test data creation and FluentAssertions for assertions.
Definitely, because of its simplicity the solution has vulnerabilities in multithreading scenarios(lacks synchronization), id generation and so on.
