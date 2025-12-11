namespace Crud.Endpoints;

using Crud.data;
using Crud.model;

public static class ProfileEndpoints
{
 public static void MapProfileEndpoints (this IEndpointRouteBuilder app) {
 var group = app.MapGroup("/api/profile");
 group.MapPost("/profile", async (ApplicationDbContext db, Profile profile) =>
 {
  db.Profiles.Add(profile);
  await db.SaveChangesAsync();
  return Results.Created($"/api/profile/{profile.Id}", profile);   
 });

    }
    
}