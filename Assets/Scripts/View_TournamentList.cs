using UnityEngine;
using UnityEngine.UI;

public class View_TournamentList : AppView
{
	private ViewName openOnBack = ViewName.Main;

    private void Start()
    {
        //TODO Load tournaments data
    }

    public override ViewName GetName()
	{
		return ViewName.TournamentList;
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
