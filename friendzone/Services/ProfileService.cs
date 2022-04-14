using System.Collections.Generic;
using friendzone.Models;
using friendzone.Repositories;

namespace friendzone.Services
{
  public class ProfileService
  {
    private readonly ProfileRepository _repo;

    public ProfileService(ProfileRepository repo)
    {
      _repo = repo;
    }

    internal List<Profile> GetAll()
    {
      return _repo.GetAll();
    }
  }
}