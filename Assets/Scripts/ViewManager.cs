using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public AppView[] views;
	
	private static ViewManager instance;
	
	private AppView.ViewName openedView = AppView.ViewName.NONE;
	
	public void Initialize()
	{
		if(instance)
		{
			Destroy(this);
		}
		else
		{
			instance = this;
			views = GameObject.FindObjectsOfType<AppView>();
			OpenView(AppView.ViewName.Main);
		}
	}
	
	#if UNITY_ANDROID || UNITY_EDITOR
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			{
				AppView.ViewName currentOpenedView = openedView;
				for(int i = 0; i < views.Length; i++)
				{
					if(views[i] && views[i].GetName() == currentOpenedView)
					{
						views[i].BackPressed();
					}
				}
			}
	}
	#endif
	
	public static ViewManager GetInstance()
	{
		return instance;
	}
	
	public void OpenView(AppView.ViewName viewName)
	{
		AppView.ViewName currentOpenedView = openedView;
		for(int i = 0; i < views.Length; i++)
		{
			if(views[i])
			{
				if(views[i].GetName() == viewName)
				{
					views[i].ViewOpened(currentOpenedView);
				}
				else
				{
					views[i].ViewClosed();
				}
			}
		}
		openedView = viewName;
	}
	
	public List<AppView> GetOpenedView()
	{
		List<AppView> view = new List<AppView>();
		for(int i = 0; i < views.Length; i++)
		{
			if(views[i] && views[i].GetName() == openedView)
			{
				view.Add(views[i]);
			}
		}
		return view;
	}
}
