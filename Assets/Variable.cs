using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Variable
{
	public String Name;
	public String Description { get; set; }

	public Variable (String name, String desc)
	{
		this.Name = name;
		Description = desc;
	}
}