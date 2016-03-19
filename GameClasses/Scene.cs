using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
	public class Setting
	{
		public String Place { get; set; }
		public String Time { get; set; }
	}


	/// <summary>
	/// A class to holds the logic in a scene
	/// </summary>
    public class Scene
    {
		public Setting Setting { get; set; }
		public List<Variable> Variables { get; set; }
 
		
	}
}
