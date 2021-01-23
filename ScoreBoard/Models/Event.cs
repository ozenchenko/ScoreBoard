using System;
using System.Threading;

namespace ScoreBoard.Models
{
    public class Event
    {
        private static int _counter = 0;

        public static int Counter { get; }

        public Event(string homeTeam, string awayTeam)
        {
            Id = _counter++;
            HomeTeam = homeTeam ?? throw new ArgumentNullException(nameof(homeTeam));
            AwayTeam = awayTeam ?? throw new ArgumentNullException(nameof(awayTeam));
        }

        public int Id { get; set; }

        public string HomeTeam { get; }
        public int HomeTeamScore { get; set; }

        public string AwayTeam { get; }
        public int AwayTeamScore { get; set; }

        public int TotalScore => HomeTeamScore + AwayTeamScore;

        public override string ToString()
        {
            return $"{HomeTeam} - {AwayTeam}: {HomeTeamScore} - {AwayTeamScore}";
        }
    }
}