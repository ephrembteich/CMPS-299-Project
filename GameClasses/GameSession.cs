using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClasses
{
	public enum GenderEnum
	{
		Boy, Girl
	}


	public class GameSession
	{
		public int Age { get; set; }
		public GenderEnum Gender { get; set; }
		public List<Scene> Scenes { get; set; }

	}
}
