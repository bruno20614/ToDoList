using System;
using System.Collections.Generic;
using Manager.Domain.Validators;
using Manager.Core.Exceptions;

namespace Manager.Domain.Entities;

	public class User : Base
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	
	//EF
	public virtual Collection<Assignment> Assignments { get; set; } = new();
	public virtual Collection<AssignmentList> AssignmentLists { get; set; } = new();


	
}



   