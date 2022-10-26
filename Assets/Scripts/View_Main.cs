using UnityEngine;
using UnityEngine.UI;

public class View_Main : AppView
{
	Button button_tournaments;
	Button button_players;
	Button button_settings;
	
	public override ViewName GetName()
	{
		return ViewName.Main;
	}
   
	public override void BackPressed()
	{
		Application.Quit();
	}
	
	public void OpenTournamentList()
	{
		ViewManager.GetInstance().OpenView(ViewName.TournamentList);
	}
	
	public void OpenPlayerDatabase()
	{
		ViewManager.GetInstance().OpenView(ViewName.PlayerDatabase);
	}
	
	public void OpenSettings()
	{
		ViewManager.GetInstance().OpenView(ViewName.Settings);
	}
}
