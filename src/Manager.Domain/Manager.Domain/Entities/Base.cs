using System.Collections.Generic;

namespace Manager.Domain.Entities;
public abstract class Base
{
	protected Base()
	{
		Id=New.Guid();

	}
    public Guid Id{get;set;}
	public DateTime CreateAt{get;set;}
	public DateTime UpdateAt{get;set;}

}