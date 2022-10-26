using UnityEngine;
using UnityEngine.UI;

public class View_PlayerDatabase : AppView
{
	public Button buttonNewPlayer;
	public Button buttonAddPlayer;
	
	private ViewName openOnBack = ViewName.Main;

	private void Start()
	{
		//TODO Load players data
	}

	public override ViewName GetName()
	{
		return ViewName.PlayerDatabase;
	}
	
	public override void ViewOpened(ViewName fromView)
	{
		base.ViewOpened(fromView);
		buttonAddPlayer.gameObject.SetActive(fromView == ViewName.TournamentSettings);
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
