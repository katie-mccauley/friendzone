namespace friendzone.Models
{
  public class Follow
  {
    public int Id { get; set; }
    public string FollowerId { get; set; }
    public string Followingid { get; set; }
  }

  public class ProfileFollow : Follow
  {
    public int ConnectId { get; set; }
  }
}