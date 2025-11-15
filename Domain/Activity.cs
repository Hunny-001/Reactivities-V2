using System;
namespace Domain;
public class Activity
{
    public string Id { get; set; } = Guid.NewGuid().ToString(); 
    // Guid.NewGuid() will create a random no. just like an ID, and it will then be stored as string, So basically GUID() used for ID purpose.
    //In .Net Core we have Convention-Based Detection, it detects if any Id word is present, it will automatically treat it as PK. So we can either use [Key] i.e to denote it as PK orelse its not required.
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public bool IsCancelled { get; set; }
    //locational properties
    public required string City { get; set; }
    public required string Venue { get; set; }
    public double Latitude { get; set; }
    public double Longitude{ get; set; }
}
//Here we get warning in "public string Vanue { get; set; }" in string properties
//So to get rid of it you can do 2 things
//1. Domain.csproj - Change "Nullable" as disable
//2. We can make it as Null, NotNull, Required
//   a. "public required string Title { get; set; }" --> Required
//   b. "public string Title { get; set; } = string.Empty;" --> It wont accept Null, since without ? C# treats as not_null and to avoid warning we need to define it with some empty value in it.
//   c. "public string ? Title { get; set; }" --> Allow Null values