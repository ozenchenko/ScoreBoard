using ScoreBoard.Models;
using System;
using System.Collections.Generic;

namespace ScoreBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();

            var event1 = new Event("Mexico", "Canada");
            board.Start(event1);
            board.Update(event1.Id, 0, 5);

            var event2 = new Event("Spain", "Brazil");
            board.Start(event2);
            board.Update(event2.Id, 10, 2);

            var event3 = new Event("Germany", "France");
            board.Start(event3);
            board.Update(event3.Id, 2, 2);

            var event4 = new Event("Uruguay", "Italy");
            board.Start(event4);
            board.Update(event4.Id, 6, 6);

            var event5 = new Event("Argentina", "Australia");
            board.Start(event5);
            board.Update(event5.Id, 3, 1);

            WriteToConsole(board.GetSummary());

            var event6 = new Event("Ukraine", "England");
            board.Start(event6);
            board.Update(event6.Id, 7, 7);

            WriteToConsole(board.GetSummary());

            board.Finish(event6.Id);

            WriteToConsole(board.GetSummary());
        }

        private static void WriteToConsole(List<Event> events)
        {
            foreach (var e in events)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine();
        }
    }
}
