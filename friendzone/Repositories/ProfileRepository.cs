using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using friendzone.Models;

namespace friendzone.Repositories
{
  public class ProfileRepository
  {
    private IDbConnection _db;

    public ProfileRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Profile> GetAll()
    {
      string sql = "SELECT * FROM accounts";
      return _db.Query<Profile>(sql).ToList();
    }
  }
}