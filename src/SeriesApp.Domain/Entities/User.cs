using System;
using Volo.Abp.Domain.Entities;

namespace SeriesApp.Entities
{
    /// <summary>
    /// Represents a user in the SeriesApp system.
    /// </summary>
    public class User : AggregateRoot<Guid>
    {
        /// <summary>
        /// The username used for login.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The full name of the user.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The hashed password for the user.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// URL or path to the user's profile picture.
        /// </summary>
        public string ProfilePicture { get; set; }

        /// <summary>
        /// Indicates whether the user has administrative privileges.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Indicates whether the user account is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// User preferences for notifications (e.g., email, screen).
        /// </summary>
        public string PreferencesNotification { get; set; }

        protected User() { }

        public User(Guid id, string userName, string fullName, string passwordHash, bool isAdmin,
            bool isActive, string preferencesNotification, string profilePicture) : base(id)
        {
            UserName = userName;
            FullName = fullName;
            PasswordHash = passwordHash;
            IsAdmin = isAdmin;
            IsActive = isActive;
            PreferencesNotification = preferencesNotification;
            ProfilePicture = profilePicture;
        }
    }
}