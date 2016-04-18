using System;

public class FoodItem
{
	public String Name {
		get;
		set;
	}

	public String Location {
		get;
		set;
	}

	public String Notes {
		get;
		set;
	}

	public FoodItem (String Name, String Location, String Notes)
	{
		this.Name = Name;
		this.Location = Location;
		this.Notes = Notes;
	}

}
