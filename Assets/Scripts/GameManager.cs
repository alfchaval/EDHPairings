using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Translator translator;
	private ViewManager viewManager;
	private DataManager dataManager;
	
	private void Start()
    {
        translator = gameObject.AddComponent<Translator>();
		translator.Initialize();
		viewManager = gameObject.AddComponent<ViewManager>();
		viewManager.Initialize();
		dataManager = gameObject.AddComponent<DataManager>();
		dataManager.Initialize();
    }
}
