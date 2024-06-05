using System;
using System.Collections.Generic;
namespace Manager.Domain.Entities;

public class Assigment : Base
{
    public string Description { get; set; }
	public int  UserId{ get; set; }
	public int AssigmentListId{ get; set; }
	public bool Concluded{ get; set; }
	public DateTime DeadLine { get; set; }
	public DateTime ConcludedAt { get; set; }

	//EF
	public User User { get; set; }
	public AssignmentList AssignmentList { get; set; }
	
}