using System.Security.Claims;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseController
{
  [HttpGet]
  public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
  {
    var users = await userRepository.GetMembersAsync();

    return Ok(users);
  }

  [HttpGet("{username}")]
  public async Task<ActionResult<MemberDto>> GetByUserName(string username)
  {
    var user = await userRepository.GetMemberAsync(username);

    if (user == null) return NotFound();

    return user;
  }

  [HttpPut]
  public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
  {
    var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (username == null) return BadRequest("No username found in token");

    var user = await userRepository.GetUserByUsernameAsync(username);

    if (user == null) return NotFound("Could not find user");

    mapper.Map(memberUpdateDto, user);

    if (await userRepository.SaveAllAsync()) return NoContent();

    return BadRequest("Failed to update user");
  }
}