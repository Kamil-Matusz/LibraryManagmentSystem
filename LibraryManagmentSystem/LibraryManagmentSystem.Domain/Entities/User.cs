namespace LibraryManagmentSystem.Domain.Entities;

public class User
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Fullname { get; set; }
    public int RoleId { get; set; }

    public User(Guid userId, string username, string email, string password, string fullname, int roleId)
    {
        UserId = userId;
        Username = username;
        Email = email;
        Password = password;
        Fullname = fullname;
        RoleId = roleId;
    }
}