using System;

namespace Assets
{
	public class Variable
	{
		public String Name;

		public Variable(String name, String desc)
		{
			Name = name;
			Description = desc;
		}

		public String Description { get; set; }
	}
}