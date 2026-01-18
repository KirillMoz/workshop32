using Microsoft.EntityFrameworkCore;

namespace StartAppMVC.Models.Db
{
    public class RequestContext: DbContext
    {
        public DbSet<Request> Requests { get; set; }

        public RequestContext(DbContextOptions<RequestContext> options)
            : base(options)
        {
            // Автоматически создаем БД при первом обращении
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка таблицы Requests
            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Url).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Date).IsRequired();

                // Индекс для быстрого поиска по дате
                entity.HasIndex(e => e.Date);

                // Создаем таблицу с именем "RequestLogs"
                entity.ToTable("RequestLogs");
            });
        }
    }
}
