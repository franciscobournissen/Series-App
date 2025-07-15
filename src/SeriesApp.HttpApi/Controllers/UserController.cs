using Microsoft.AspNetCore.Mvc;
using SeriesApp.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SeriesApp.Controllers;

[Route("api/users")]
public class UserController : AbpController
{
    private readonly IUserAppService _userAppService;

    public UserController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpGet]
    public async Task<List<UserDto>> GetAllAsync()
    {
        return await _userAppService.GetAllAsync();
    }

    [HttpPost]
    public async Task<UserDto> CreateAsync([FromBody] CreateUserInput input)
    {
        return await _userAppService.CreateAsync(input);
    }

    [HttpGet("{id}")]
    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        return await _userAppService.GetByIdAsync(id);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        await _userAppService.DeleteAsync(id);
    }
}