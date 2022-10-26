using UnityEngine;
using UnityEngine.UI;

public class View_Pairing : AppView
{
	private ViewName openOnBack = ViewName.TournamentSettings;
	
	public override ViewName GetName()
	{
		return ViewName.Pairing;
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
