namespace OAuthDemo.Repositories
{
    public class UserRepository
    {
        public bool FindUser(string username, string password)
        {
            return username == "admin" && password == "1234";
        }
    }
}