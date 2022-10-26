using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    private static Translator instance;
	private Language selectedLanguage = Language.English;
	
	public void Initialize()
	{
		if(instance)
		{
			Destroy(this);
		}
		else
		{
			instance = this;
		}
		selectedLanguage = (Language)PlayerPrefs.GetInt("language", (int)Language.English);
	}
	
	public static Translator GetInstance()
	{
		return instance;
	}
	
	public void SetLanguage(Language lan)
	{
		selectedLanguage = lan;
		PlayerPrefs.SetInt("language", (int)lan);
	}
	
	public Language GetLanguage()
	{
		return selectedLanguage;
	}
	
	public enum Language
	{
		English,
		Spanish
	}
	
	public string GetLocalizedText(StringId id)
	{
		switch(id)
		{
			case StringId.Main_Button_Tournaments:
				switch(selectedLanguage)
				{
					case Language.English: return "Tournaments";
					case Language.Spanish: return "Torneos";
				}
				break;
			case StringId.Main_Button_Players:
				switch(selectedLanguage)
				{
					case Language.English: return "Players";
					case Language.Spanish: return "Jugadores";
				}
				break;
			case StringId.Main_Button_Settings:
				switch(selectedLanguage)
				{
					case Language.English: return "Settings";
					case Language.Spanish: return "Ajustes";
				}
				break;
		}
		return "";
	}
	
	public enum StringId
	{
		Main_Button_Tournaments,
		Main_Button_Players,
		Main_Button_Settings,
	}
}
