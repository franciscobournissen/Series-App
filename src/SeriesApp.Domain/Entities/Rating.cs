using System;
using Volo.Abp.Domain.Entities;

namespace SeriesApp.Entities
{
    public class Rating : AggregateRoot<Guid>
    {
        public User User { get; set; }
        public Serie Serie { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }

        private Rating()
        {
        }

        public Rating(Guid id, User user, Serie serie, int rate, string comment) : base(id)
        {
            User = user;
            Serie = serie;
            Rate = rate;
            Comment = comment;
        }
    }
}