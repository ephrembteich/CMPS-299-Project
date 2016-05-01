using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

/// <summary>
/// A class to holds the logic in a scene
/// </summary>
public class Scene
{
	public String SceneName { get; set; }

	public String Place { get; set; }

	public String Time { get; set; }

	public List<Variable> Variables { get; set; }

	//public Variable variable;

	public String result;

	public String SelectedFoodItem { get; set; }

	public Scene(String SceneName){
		this.SceneName = SceneName;
		Variables = new List<Variable> ();
	}

	public String GetResult(){
		result += SceneName;
		foreach(Variable varr in Variables){
			result += varr.Description;
		}

		result += SelectedFoodItem;
		return result;
	}

}
