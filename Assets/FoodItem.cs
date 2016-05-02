using System;

namespace Assets
{
	public class FoodItem
	{
		public FoodItem(String name, String location, String notes)
		{
			this.Name = name;
			this.Location = location;
			this.Notes = notes;
		}

		public String Name { get; set; }
		public String Location { get; set; }
		public String Notes { get; set; }
	}
}