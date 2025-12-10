using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class UserService(ApplicationDbContext applicationDbContext)
    {
        private readonly ApplicationDbContext _context = applicationDbContext;

        public Users[] GetAllUsers()
        {
            return [.. _context.Users];
        }
    }
}
