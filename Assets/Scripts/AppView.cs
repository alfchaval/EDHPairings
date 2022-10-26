using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppView : MonoBehaviour
{
	public GameObject content;
	public TranslatableText[] textToTranslate;
	
	public virtual ViewName GetName()
	{
		return ViewName.NONE;
	}
	
	public virtual void ViewOpened(ViewName fromView)
	{
		if(content)
		{
			content.SetActive(true);
			TranslateContent();
		}
	}
	
	public virtual void ViewClosed()
	{
		if(content)
		{
			content.SetActive(false);
		}
	}
	
	private void TranslateContent()
	{
		for(int i = 0; i < textToTranslate.Length; i++)
		{
			textToTranslate[i].Translate();
		}
	}
	
	public virtual void BackPressed()
	{
		
	}
	
	public enum ViewName
	{
		NONE,
		Main,
		Tournaments,
		Players,
		Settings,
		PlayerDatabase,
		TournamentList,
		TournamentSettings,
		Round,
		Pairing,
		Standings
	}
}
