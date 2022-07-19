namespace Ejournal.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(EjournalDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
