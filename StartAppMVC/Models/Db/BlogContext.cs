using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StartAppMVC.Models.Db
{
    public sealed class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        /// Ссылка на таблицу UserPosts
        public DbSet<UserPost> UserPosts { get; set; }

        public DbSet<Request> Requests { get; set; }

        // Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
