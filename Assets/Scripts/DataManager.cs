using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	private static DataManager instance;
	
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
	}
	
	public static DataManager GetInstance()
	{
		return instance;
	}
	
	/*
	public static void WriteDataToJson() {
        string dataString;
        string jsonFilePath = DataPath();
        CheckFileExistance(jsonFilePath);
 
        dataString = JsonUtility.ToJson(savedData);
        File.WriteAllText(jsonFilePath, dataString);
}

public static SavedData ReadDataFromJson() {
        string dataString;
        string jsonFilePath = DataPath();
        CheckFileExistance(jsonFilePath, true);
 
        dataString = File.ReadAllText(jsonFilePath);
        loadedData = JsonUtility.FromJson<SavedData>(dataString);
        return loadedData;
}

static string DataPath() {
        if (Directory.Exists(Application.persistentDataPath)) {
            return Path.Combine(Application.persistentDataPath, jsonFileName);
        }
        return Path.Combine(Application.streamingAssetsPath, jsonFileName);
}

static void CheckFileExistance(string filePath, bool isReading = false) {
        if (!File.Exists(filePath)){
            File.Create(filePath).Close();
            if (isReading) {
                SetStartingData();
                string dataString = JsonUtility.ToJson(savedData);
                File.WriteAllText(filePath, dataString);
            }
        }
}
*/
}
