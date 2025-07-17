using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SeriesApp.Dtos;
using SeriesApp.Entities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace SeriesApp;

public class UserAppService : ApplicationService, IUserAppService
{
    private readonly IRepository<User, Guid> _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserAppService(IRepository<User, Guid> userRepository, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetListAsync();
        return ObjectMapper.Map<List<User>, List<UserDto>>(users);
    }
    
    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetAsync(id);
        return ObjectMapper.Map<User, UserDto>(user);
    }

    public async Task<UserDto> CreateAsync(CreateUserInput input)
    {
        var hashedPassword = _passwordHasher.HashPassword(null, input.Password);

        var user = new User(
            id: Guid.NewGuid(),
            userName: input.UserName,
            fullName: input.FullName,
            passwordHash: hashedPassword,
            isAdmin: input.IsAdmin,
            isActive: true,
            preferencesNotification: string.IsNullOrWhiteSpace(input.PreferencesNotification)
                ? "screen"
                : input.PreferencesNotification,
            profilePicture: input.ProfilePicture
        );

        await _userRepository.InsertAsync(user, autoSave: true);

        return ObjectMapper.Map<User, UserDto>(user);
    }


    public async Task DeleteAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }
}