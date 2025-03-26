using System;

namespace SeriesApp.Entities
{
    public class Administrator : User
    {
        private Administrator() { } // Constructor vacío para EF Core

        public Administrator(Guid id, string userName, string fullName, string passwordHash, bool isAdmin, 
            bool isActive, string preferencesNotification)
            : base(id, userName, fullName, passwordHash, isAdmin, isActive, preferencesNotification)
        {
        }
    }
}