using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
	public class Feedback : MonoBehaviour
	{
		string [] does = {"Junk food is bad for your health", "Candy and sweets damage your teeth",
			"Soft drinks lead to sugar overload", "Chips and fried potato cause obesity"};
		string[] donts = {"A healthy diet contains vegetables and fruits", "Dairy products strengthen your bones",
			"Meat contains a lot of protein", "Salads have healthy fibers"};

		public Text t;

		private System.Random rG;

		void Start(){
			rG = new System.Random ();
			t.text = does[rG.Next(0, 4)]+"\n\n"+donts[rG.Next(0, 4)];
		}

		public void Exit()
		{
			Application.Quit();
		}
	}
}