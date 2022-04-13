using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using friendzone.Models;
using friendzone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace friendzone.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/[controller]")]
  public class FollowController : ControllerBase
  {

    private readonly FollowService _fs;

    public FollowController(FollowService fs)
    {
      _fs = fs;
    }


    [HttpPost]
    public async Task<ActionResult<Follow>> Create([FromBody] Follow followData)
    {
      Account user = await HttpContext.GetUserInfoAsync<Account>();
      followData.FollowerId = user.Id;
      Follow follow = _fs.Create(followData);
      return Ok(follow);
    }
  }
}