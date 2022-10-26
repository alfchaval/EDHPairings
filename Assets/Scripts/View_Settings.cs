using UnityEngine;
using UnityEngine.UI;

public class View_Settings : AppView
{
	private ViewName openOnBack = ViewName.Main;
	
	public override ViewName GetName()
	{
		return ViewName.Settings;
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
