using System.Collections.Generic;
using friendzone.Models;
using friendzone.Repositories;

namespace friendzone.Services
{
  public class FollowService
  {
    private readonly FollowRepository _repo;

    public FollowService(FollowRepository repo)
    {
      _repo = repo;
    }

    internal Follow Create(Follow followData)
    {
      return _repo.Create(followData);
    }

    internal List<FriendZoneViewModel> GetFollowing(string id)
    {
      return _repo.GetFollowing(id);
    }
  }
}