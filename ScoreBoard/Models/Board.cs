using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreBoard.Models
{
    public class Board
    {
        public List<Event> Events { get; }

        public Board()
        {
            Events = new List<Event>();
        }


        public void Start(Event e)
        {
            Events.Add(e);
        }

        public void Finish(int eventId)
        {
            var e = GetEvent(eventId);

            Events.Remove(e);
        }

        public void Update(int eventId, int homeTeamScore, int awayTeamScore)
        {
            var e = GetEvent(eventId);

            e.HomeTeamScore = homeTeamScore;
            e.AwayTeamScore = awayTeamScore;
        }

        private Event GetEvent(int eventId)
        {
            var e = Events.SingleOrDefault(g => g.Id == eventId);

            if (e == null)
            {
                throw new ArgumentException("Event with the specified id does not exist", nameof(eventId));
            }

            return e;
        }

        public string GetSummary()
        {
            var orderedEvents = Events.OrderByDescending(e => e.HomeTeamScore + e.AwayTeamScore).ThenByDescending(e => e.Id).ToList();
            var summaryStrBuilder = new StringBuilder();

            foreach (var e in orderedEvents)
            {
                summaryStrBuilder.AppendLine(e.ToString());
            }

            return summaryStrBuilder.ToString();
        }
    }
}
