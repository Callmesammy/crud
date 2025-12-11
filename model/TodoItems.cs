namespace Crud.model; 

public class Profile
{
    public int Id {get; set;}
    public string About {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
}