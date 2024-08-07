using System.Text.Json.Serialization;
using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class User : BaseAuditableEntity<int?, User>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    [JsonIgnore]
    public ICollection<User> Followers { get; } = [];
    [JsonIgnore]
    public ICollection<User> Follows { get; } = [];
}
