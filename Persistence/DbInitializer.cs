using System;
using Domain;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext obj)
    //async Task<int> GetNumberAsync() : Syntax when we need to return int
    //async : This method contains asynchronous operations that might take time (like database or file I/O). 
    //        Let other code run while this method waits(i.e user can use other UI options)
    //Task : I’ll do this job in the background and let you know when it’s done

    {
        if (obj.Activities.Any()) return;
        //.Any() checks whether any rows exist in that table Activities
        var xx = new List<Activity>
        {
            new() {
                Title = "Past Activity 1",
                Date = DateTime.Now.AddMonths(-2),
                Description = "Activity 2 months ago",
                Category = "drinks",
                City = "London",
                Venue = "The Lamb and Flag, 33, Rose Street, Seven Dials, Covent Garden, London, Greater London, England, WC2E 9EB, United Kingdom",
                Latitude = 51.51171665,
                Longitude = -0.1256611057818921,
            },
            new() {
                Title = "Past Activity 2",
                Date = DateTime.Now.AddMonths(-1),
                Description = "Activity 1 month ago",
                Category = "culture",
                City = "Paris",
                Venue = "Louvre Museum, Rue Saint-Honoré, Quartier du Palais Royal, 1st Arrondissement, Paris, Ile-de-France, Metropolitan France, 75001, France",
                Latitude = 48.8611473,
                Longitude = 2.33802768704666
            },
            new() {
                Title = "Future Activity 1",
                Date = DateTime.Now.AddMonths(1),
                Description = "Activity 1 month in future",
                Category = "culture",
                City = "London",
                Venue = "Natural History Museum",
                Latitude = 51.496510900000004,
                Longitude = -0.17600190725447445
            },
            new() {
                Title = "Future Activity 2",
                Date = DateTime.Now.AddMonths(2),
                Description = "Activity 2 months in future",
                Category = "music",
                City = "London",
                Venue = "The O2",
                Latitude = 51.502936649999995,
                Longitude = 0.0032029278126681844
            },
            new()
            {
                Title = "Future Activity 3",
                Date = DateTime.Now.AddMonths(3),
                Description = "Activity 3 months in future",
                Category = "drinks",
                City = "London",
                Venue = "The Mayflower",
                Latitude = 51.501778,
                Longitude = -0.053577
            },
            new()
            {
                Title = "Future Activity 4",
                Date = DateTime.Now.AddMonths(4),
                Description = "Activity 4 months in future",
                Category = "drinks",
                City = "London",
                Venue = "The Blackfriar",
                Latitude = 51.512146650000005,
                Longitude = -0.10364680647106028
            },
            new()
            {
                Title = "Future Activity 5",
                Date = DateTime.Now.AddMonths(5),
                Description = "Activity 5 months in future",
                Category = "culture",
                City = "London",
                Venue = "Sherlock Holmes Museum, 221b, Baker Street, Marylebone, London, Greater London, England, NW1 6XE, United Kingdom",
                Latitude = 51.5237629,
                Longitude = -0.1584743
            },
            new()
            {
                Title = "Future Activity 6",
                Date = DateTime.Now.AddMonths(6),
                Description = "Activity 6 months in future",
                Category = "music",
                City = "London",
                Venue = "Roundhouse, Chalk Farm Road, Maitland Park, Chalk Farm, London Borough of Camden, London, Greater London, England, NW1 8EH, United Kingdom",
                Latitude = 51.5432505,
                Longitude = -0.15197608174931165
            },
            new()
            {
                Title = "Future Activity 7",
                Date = DateTime.Now.AddMonths(7),
                Description = "Activity 2 months ago",
                Category = "travel",
                City = "London",
                Venue = "River Thames, England, United Kingdom",
                Latitude = 51.5575525,
                Longitude = -0.781404
            },
            new()
            {
                Title = "Future Activity 8",
                Date = DateTime.Now.AddMonths(8),
                Description = "Activity 8 months in future",
                Category = "film",
                City = "London",
                Venue = "River Thames, England, United Kingdom",
                Latitude = 51.5575525,
                Longitude = -0.781404
            }
            //This is the in-memory collection of new records you intend to insert
        };
        obj.Activities.AddRange(xx);
        //Adds all items in the xx list to the Activities DbSet in the DbContext’s change tracker.
        //AddRange is efficient when adding multiple entities at once (better than multiple Add calls).
        //At this point the entities are tracked as Added but NOT yet saved to the database.

        await obj.SaveChangesAsync();
        //Persists all tracked changes to the database asynchronously.
        //This sends SQL INSERT commands and waits for the DB to finish.
        //await : Pause this method here until the awaited Task finishes, but don’t block the thread — let other work continue in the meantime
        //        So the method pauses logically but the thread is free to do other things
        //


        //Explaination of async Task and await
        // Eg: Restaurant kitchen 🍽️
        // The chef (thread) can cook multiple dishes.
        // If a dish is baking in the oven (a slow operation), the chef doesn’t stand idle.
        // He moves on to prepare the next order.
        // When the oven beeps (task completes), he returns to finish the dish.
        // That’s exactly what await allows your program to do — not block the chef while something slow happens.
    }
}
