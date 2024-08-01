public class Follow
{
    public int FollowID { get; set; }
    public int FollowerID { get; set; }
    public int FollowingID { get; set; }
    public User Follower { get; set; }
    public User Following { get; set; }
}