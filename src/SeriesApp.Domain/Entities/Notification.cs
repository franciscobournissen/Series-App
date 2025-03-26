using System;
using System.Runtime.InteropServices.JavaScript;
using Volo.Abp.Domain.Entities;

namespace SeriesApp.Entities
{
    public class Notification : Entity<Guid>
    {
        public User User { get; private set; }
        public string Message { get; private set; }
        public DateTime Date { get; private set; }
        public bool IsRead { get; private set; }
        
        private Notification() {}

        public Notification(Guid id, User user, string message, DateTime date, bool isRead) : base(id)
        {
            User = user;
            Message = message;
            Date = date;
            IsRead = isRead;
        }
    }
}