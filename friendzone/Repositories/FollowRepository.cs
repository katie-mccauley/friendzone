using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using friendzone.Models;

namespace friendzone.Repositories
{
  public class FollowRepository
  {
    private readonly IDbConnection _db;

    public FollowRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Follow Create(Follow followData)
    {
      string sql = @"
        INSERT INTO follow
        (followingId, followerId)
        VALUES 
        (@FollowingId, @FollowerId);
        SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, followData);
      followData.Id = id;
      return followData;
    }

    internal List<FriendZoneViewModel> GetFollowers(string id)
    {
      string sql = @"
      SELECT 
      a.*,
      f.id AS ConnectId
      FROM follow f
      JOIN accounts a ON a.id = f.followerId
      WHERE f.followingId = @id;
      
      ";
      return _db.Query<FriendZoneViewModel>(sql, new { id }).ToList();
    }

    internal List<FriendZoneViewModel> GetFollowing(string id)
    {
      string sql = @"
      SELECT 
      a.*, 
      f.id AS ConnectId
      FROM follow f
      JOIN accounts a ON a.id = f.followingId
      WHERE f.followerId = @id;
      ";
      return _db.Query<FriendZoneViewModel>(sql, new { id }).ToList();
    }
  }
}