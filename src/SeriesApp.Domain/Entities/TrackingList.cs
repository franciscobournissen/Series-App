using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace SeriesApp.Entities
{
    public class TrackingList : AggregateRoot<Guid>
    {
        public User User { get; set; }
        public List<Serie> Series { get; set; } = new List<Serie>();

        private TrackingList() { }

        public TrackingList(Guid id, User user) : base(id)
        {
            User = user;
            Series = new List<Serie>();
        }
    }
}