namespace testEntityCoreCrudWControllers.Entities;

public class User
{
    public int userID { get; set; }
    
    public required string userName { get; set; }
    
    public required string password { get; set; }
}