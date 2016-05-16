using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
	[Serializable]
	public class ServerVariable
	{
		public String Name;

		public String Description;

		public int VariableNumber;

		public ServerVariable()
		{
		}

		public ServerVariable(String name, int variableNum)
		{
			Name = name;
			VariableNumber = variableNum;
		}
	}
}
