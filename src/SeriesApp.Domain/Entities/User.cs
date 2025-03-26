using System;
using Volo.Abp.Domain.Entities;

namespace SeriesApp.Entities
{
    public class User : AggregateRoot<Guid>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string PreferencesNotification { get; set; }

        protected User() {}

        public User(Guid id, string userName, string fullName, string password, bool isAdmin,
            bool isActive, string preferencesNotification) : base(id)
        {
            UserName = userName;
            FullName = fullName;
            Password = password;
            IsAdmin = isAdmin;
            IsActive = isActive;
            PreferencesNotification = preferencesNotification;
        }
    }
}