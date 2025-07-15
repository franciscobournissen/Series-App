/*using System;
using Microsoft.AspNetCore.Identity;
using SeriesApp.Entities;

class Program
{
    static void Main()
    {
        var hasher = new PasswordHasher<User>();
        // Crear una instancia de User con valores ficticios
        var user = new User(
            id: Guid.NewGuid(),
            userName: "tempuser",
            fullName: "Temp User",
            passwordHash: "", // No se usa para hashear
            isAdmin: false,
            isActive: true,
            preferencesNotification: "email",
            profilePicture: ""
        );
        var password = "MySecurePassword123!";
        var hashedPassword = hasher.HashPassword(user, password);
        Console.WriteLine($"Password Hash: {hashedPassword}");
    }
}*/