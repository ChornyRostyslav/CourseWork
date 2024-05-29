namespace OOP_KR
{
    public interface ILoginUser : IUser
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
