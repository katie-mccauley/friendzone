using System;
using System.Collections.Generic;
using friendzone.Models;
using friendzone.Services;
using Microsoft.AspNetCore.Mvc;

namespace friendzone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase

  {
    private readonly AccountService _accountService;

    private readonly FollowService _fs;

    public ProfilesController(AccountService accountService, FollowService fs)
    {
      _accountService = accountService;
      _fs = fs;
    }

    [HttpGet("{id}/following")]
    public ActionResult<List<FriendZoneViewModel>> Getfollowing(string id)
    {
      try
      {
        List<FriendZoneViewModel> following = _fs.GetFollowing(id);
        return Ok(following);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}