using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController(AppDbContext obj) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await obj.Activities.ToListAsync();
        //await is always used when function has Task in it
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivitiesById(string id)
    {
        var xx = await obj.Activities.FindAsync(id);
        if (xx == null) return NotFound();
        return xx;
    }

    [HttpGet]
    public async Task<ActionResult<Activity>> GetActivitiesByIdTemp(string id)
    {
        var xx = await obj.Activities.FindAsync(id);
        if (xx == null) return NotFound();
        return xx;
    }
}
