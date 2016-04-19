using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTTP;


public class GameSession
{
	public int Age { get; set; }

	public CookieAccessInfo c;

	public String Gender { get; set; }

	public List<Scene> Scenes { get; set; }

	public Scene currentScene { get; set; }

	private static GameSession Session;

	public LinkedList<String> Results;

	private GameSession (){
		Results = new LinkedList <String>();
	}

	public void WriteResult(){
		Results.AddLast("Scene: " + currentScene.SceneName + " "  );
	}

	public static GameSession getSession ()
	{
		if (Session == null) {
			Session = new  GameSession ();
		}
		return Session;
	}
		
}

