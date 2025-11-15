using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
// AppDbContext will inherit DbContext class which is defined in Microsoft.EntityFrameworkCore
//AppDbContext must have a constructor since Program.cs file is getting connStr through that constructor
{
    public DbSet<Activity> Activities { get; set; }
}
