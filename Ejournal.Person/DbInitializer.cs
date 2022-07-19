namespace Ejournal.Person
{
    public class DbInitializer
    {
        public static void Initialize(PersonDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
