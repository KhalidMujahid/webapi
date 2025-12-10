namespace WebApi.Services
{
    public class UserService
    {
        private readonly string[] users = { "Ahmed", "Musa", "Yahya" };
        public string[] GetAllUsers()
        {
            return users;
        }
    }
}