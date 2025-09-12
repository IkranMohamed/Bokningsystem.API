using Bokningsystem.API.Data;
using Bokningsystem.API.Models;

public static class SeedData
{
    public static void EnsureSeedData(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Anvandare.Any())
        {
            var anvandare = new Anvandare
            {
                Namn = "Test Användare",
                Email = "test@test.com"
            };
            context.Anvandare.Add(anvandare);

            var tjanst = new Tjanst
            {
                Namn = "Test Tjänst",
                Beskrivning = "Test beskrivning",
                Pris = 100
            };
            context.Tjanster.Add(tjanst);

            context.Bokningar.Add(new Bokning
            {
                Anvandare = anvandare,
                Tjanst = tjanst,
                DatumTid = DateTime.UtcNow.AddHours(1)
            });

            context.SaveChanges();
        }
    }
}
