using UnityEngine;
using UnityEngine.UI;

public class View_TournamentSettings : AppView
{
	private ViewName openOnBack = ViewName.TournamentList;
	
	public override ViewName GetName()
	{
		return ViewName.TournamentSettings;
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
