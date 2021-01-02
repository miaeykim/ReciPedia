using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public EFUserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<User> Users => context.Users;
        public void SaveUser(User user)
        {
            if (user.UserID == 0)
            {
                context.Users.Add(user);
            }
            else
            {
                User userEntry = context.Users.FirstOrDefault(p => p.UserID == user.UserID);
                if (userEntry != null)
                {
                    userEntry.Email = user.Email;
                }
            }
            context.SaveChanges();
        }
    }
}
