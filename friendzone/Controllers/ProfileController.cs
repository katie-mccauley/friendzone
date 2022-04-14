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
    private readonly ProfileService _ps;

    public ProfilesController(AccountService accountService, FollowService fs, ProfileService ps)
    {
      _accountService = accountService;
      _fs = fs;
      _ps = ps;
    }

    [HttpGet]
    public ActionResult<List<Profile>> GetAll()
    {
      try
      {
        List<Profile> profiles = _ps.GetAll();
        return Ok(profiles);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
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

    [HttpGet("{id}/followers")]
    public ActionResult<List<FriendZoneViewModel>> Getfollowers(string id)
    {
      try
      {
        List<FriendZoneViewModel> followers = _fs.GetFollowers(id);
        return Ok(followers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}