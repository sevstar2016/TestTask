namespace GQL;

public class DbInit
{
    public static void Initialize(CarContext context)
    {
        context.Database.EnsureCreated();
        context.SaveChanges();
    }
}