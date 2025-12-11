namespace Crud.Endpoints;

using Crud.data;
using Crud.model;
using Microsoft.EntityFrameworkCore;

public static class ProfileEndpoints
{
 public static void MapProfileEndpoints (this IEndpointRouteBuilder app) {
 var group = app.MapGroup("/api/profiles");
 group.MapPost("/profile", async (ApplicationDbContext db, Profile profile) =>
 {
  db.Profiles.Add(profile);
  await db.SaveChangesAsync();
  return Results.Created($"/api/profiles/{profile.Id}", profile);   
 });
group.MapGet("/", async(ApplicationDbContext db) =>
{
    await db.Profiles.OrderByDescending(p => p.CreatedAt).ToListAsync();
});

 group.MapGet("/{id:int}", async (ApplicationDbContext db, int id) =>
 {
     var profile = await db.Profiles.FindAsync(id);
     return profile is null ? Results.NotFound() : Results.Ok(profile);
 });

    }
    
}