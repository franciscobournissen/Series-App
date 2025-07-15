using System;

namespace SeriesApp.Dtos
{
    public class CreateUserInput
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string ProfilePicture { get; set; }

        public bool IsAdmin { get; set; }

        public string PreferencesNotification { get; set; } = "screen"; // Valor por defecto
    }
}