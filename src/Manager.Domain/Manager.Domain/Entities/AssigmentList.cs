namespace Manager.Domain.Entities;

public class AssigmentList : Base
{
    string Name { get; set; }
    int UserId { get; set; }
	
	//EF
	public virtual User User { get; set; }
    public virtual Collection<Assignment> Assignments { get; set; } = new();

	
}