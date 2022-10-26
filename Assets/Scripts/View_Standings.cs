using UnityEngine;
using UnityEngine.UI;

public class View_Standings : AppView
{
	private ViewName openOnBack = ViewName.TournamentSettings;
	
	public override ViewName GetName()
	{
		return ViewName.Standings;
	}
	
	public override void BackPressed()
	{
		ViewManager viewManager = ViewManager.GetInstance();
		if(viewManager)
		{
			viewManager.OpenView(openOnBack);
		}
	}
}
