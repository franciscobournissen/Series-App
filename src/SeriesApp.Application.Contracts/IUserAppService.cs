using SeriesApp.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeriesApp;

public interface IUserAppService
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto> CreateAsync(CreateUserInput input);
    Task DeleteAsync(Guid id);
    Task<UserDto> GetByIdAsync(Guid id);

}